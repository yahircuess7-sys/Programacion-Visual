using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Word = Microsoft.Office.Interop.Word;

namespace Threads1
{
    public partial class Form1 : Form
    {
        // ===== VARIABLES PARA CAPTURAR EL PROCESO DE ORDENAMIENTO =====
        // Guardamos "fotos" del estado de las listas durante el ordenamiento
        // para poder analizar después cómo fue evolucionando cada algoritmo
        private int snapshotCount = 10; // Cuántas fotos queremos tomar de cada algoritmo
        private List<List<int>> snapshotsBurbuja = new List<List<int>>();
        private List<List<int>> snapshotsQuick = new List<List<int>>();
        private List<List<int>> snapshotsMerge = new List<List<int>>();
        private List<List<int>> snapshotsSelection = new List<List<int>>();

        // ===== DATOS PARA ORDENAR =====
        // Cada algoritmo necesita su propia copia porque si no se mezclarian
        // y un algoritmo arruinaría el trabajo de otro
        private List<int> listaOriginal;    // Los números desordenados originales
        private List<int> listaBurbuja;     // Copia para Bubble Sort
        private List<int> listaQuick;       // Copia para QuickSort  
        private List<int> listaMerge;       // Copia para MergeSort
        private List<int> listaSelection;   // Copia para SelectionSort

        // ===== CONTROL DE LOS HILOS =====
        // Necesitamos poder detener los algoritmos si el usuario quiere
        private Thread hiloBurbuja;          // Hilo tradicional para Burbuja
        private volatile bool cancelarBurbuja;   // volatile asegura que todos los hilos vean el valor actualizado
        private volatile bool cancelarMerge;
        private volatile bool cancelarSelection;

        // Contadores para saber qué tan avanzado va cada algoritmo
        private int quickPivotesColocados;   // Cuántos pivotes ha colocado QuickSort
        private int mergeProgresoContador;   // Cuántas fusiones ha hecho MergeSort

        // ===== CRONOMETROS =====
        // Cada algoritmo tiene su propio cronómetro para medir su velocidad
        private Stopwatch relojBurbuja = new Stopwatch();
        private Stopwatch relojQuick = new Stopwatch();
        private Stopwatch relojMerge = new Stopwatch();
        private Stopwatch relojSelection = new Stopwatch();

        public Form1()
        {
            InitializeComponent();

            // Configuramos el BackgroundWorker que usará QuickSort
            // Esto nos permite reportar progreso y cancelar fácilmente
            backgroundWorkerQuickSort.WorkerReportsProgress = true;
            backgroundWorkerQuickSort.WorkerSupportsCancellation = true;

            // Nos aseguramos de que los eventos no estén duplicados
            // (esto evita que se ejecuten múltiples veces)
            backgroundWorkerQuickSort.DoWork -= backgroundWorkerQuickSort_DoWork;
            backgroundWorkerQuickSort.ProgressChanged -= backgroundWorkerQuickSort_ProgressChanged;
            backgroundWorkerQuickSort.RunWorkerCompleted -= backgroundWorkerQuickSort_RunWorkerCompleted;

            // Conectamos los eventos a sus métodos
            backgroundWorkerQuickSort.DoWork += backgroundWorkerQuickSort_DoWork;
            backgroundWorkerQuickSort.ProgressChanged += backgroundWorkerQuickSort_ProgressChanged;
            backgroundWorkerQuickSort.RunWorkerCompleted += backgroundWorkerQuickSort_RunWorkerCompleted;

            // Preparamos el gráfico para mostrar los resultados
            if (chartResultados.Series.Count == 0)
            {
                chartResultados.Series.Add("Tiempos");
                chartResultados.Series["Tiempos"].ChartType = SeriesChartType.Column;
            }
        }

        // ===== BOTÓN GENERAR DATOS =====
        // Crea una lista de números aleatorios para ordenar
        private void button1_Click(object sender, EventArgs e)
        {
            int n = 100000;
            if (numericCantidad != null) n = (int)numericCantidad.Value;

            Random rnd = new Random();
            listaOriginal = new List<int>(n);
            for (int i = 0; i < n; i++)
                listaOriginal.Add(rnd.Next(0, 1000000));

            MessageBox.Show($"Lista generada correctamente con {n} números.");
        }

        // ===== BOTÓN INICIAR ORDENAMIENTOS =====
        // Lanza los 4 algoritmos al mismo tiempo usando diferentes técnicas
        private void button2_Click(object sender, EventArgs e)
        {
            if (listaOriginal == null || listaOriginal.Count == 0)
            {
                MessageBox.Show("Primero genera los datos.");
                return;
            }

            // Reiniciamos las banderas de cancelación
            cancelarBurbuja = false;
            cancelarMerge = false;
            cancelarSelection = false;

            // Cada algoritmo trabaja con su propia copia de los datos
            // Esto es importante porque si todos modificaran la misma lista
            // se interferirían entre sí
            listaBurbuja = new List<int>(listaOriginal);
            listaQuick = new List<int>(listaOriginal);
            listaMerge = new List<int>(listaOriginal);
            listaSelection = new List<int>(listaOriginal);

            // Limpiamos las fotos anteriores
            snapshotsBurbuja.Clear();
            snapshotsQuick.Clear();
            snapshotsMerge.Clear();
            snapshotsSelection.Clear();

            // Tomamos una foto del estado inicial (antes de ordenar)
            RecordSnapshot(listaBurbuja, snapshotsBurbuja);
            RecordSnapshot(listaQuick, snapshotsQuick);
            RecordSnapshot(listaMerge, snapshotsMerge);
            RecordSnapshot(listaSelection, snapshotsSelection);

            quickPivotesColocados = 0;
            ResetProgressLabels();

            // LANZAMOS LOS 4 ALGORITMOS EN PARALELO:

            // 1. BUBBLE SORT - Usando Thread tradicional
            // Elegí Thread para Burbuja porque es el algoritmo más simple
            hiloBurbuja = new Thread(OrdenarBurbuja);
            hiloBurbuja.IsBackground = true; // El hilo se cerrará cuando la app se cierre
            hiloBurbuja.Start();

            // 2. QUICKSORT - Usando BackgroundWorker
            // BackgroundWorker es ideal para operaciones largas con actualización de UI
            if (!backgroundWorkerQuickSort.IsBusy)
                backgroundWorkerQuickSort.RunWorkerAsync(listaQuick);

            // 3. SELECTION SORT y 4. MERGE SORT - Usando Tasks
            // Tasks son más modernos y fáciles de usar que los Threads tradicionales
            Task.Run(() => OrdenarSelection());
            Task.Run(() => OrdenarMerge());
        }

        // ===== BOTÓN DETENER =====
        // Detiene todos los algoritmos que están ejecutándose
        private void btnDetener_Click(object sender, EventArgs e)
        {
            // Para Bubble Sort (Thread tradicional)
            cancelarBurbuja = true;

            // Para QuickSort (BackgroundWorker)
            if (backgroundWorkerQuickSort != null && backgroundWorkerQuickSort.IsBusy)
            {
                try
                {
                    backgroundWorkerQuickSort.CancelAsync();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error cancelando QuickSort: " + ex.Message);
                }
            }

            // Para MergeSort y SelectionSort (Tasks)
            cancelarMerge = true;
            cancelarSelection = true;

            // Esperamos un poco a que el hilo de Burbuja reaccione
            if (hiloBurbuja != null && hiloBurbuja.IsAlive)
            {
                hiloBurbuja.Join(500); // Espera máximo 500ms
            }
        }

        // Reinicia las barras de progreso y etiquetas
        private void ResetProgressLabels()
        {
            progressBurbuja.Value = 0; lblBurbuja.Text = "Burbuja: 0%";
            progressQuickSort.Value = 0; lblQuickSort.Text = "QuickSort: 0%";
            if (progressMerge != null) { progressMerge.Value = 0; lblMerge.Text = "Merge: 0%"; }
            if (progressSelection != null) { progressSelection.Value = 0; lblSelection.Text = "Selection: 0%"; }
        }

        // ===== ALGORITMO BUBBLE SORT =====
        // Es el más simple pero también el más lento
        // Compara cada elemento con su vecino y los intercambia si están en desorden
        private void OrdenarBurbuja()
        {
            relojBurbuja.Restart();
            int n = listaBurbuja.Count;

            for (int i = 0; i < n - 1; i++)
            {
                if (cancelarBurbuja) break;

                for (int j = 0; j < n - i - 1; j++)
                {
                    if (cancelarBurbuja) break;
                    if (listaBurbuja[j] > listaBurbuja[j + 1])
                    {
                        // Intercambiamos los elementos
                        int temp = listaBurbuja[j];
                        listaBurbuja[j] = listaBurbuja[j + 1];
                        listaBurbuja[j + 1] = temp;
                    }
                }

                // Cada 100 iteraciones actualizamos el progreso
                // No lo hacemos en cada iteración porque sería muy lento
                if (i % 100 == 0)
                {
                    int progreso = (int)((i / (float)n) * 100);
                    this.Invoke(new Action(() =>
                    {
                        progressBurbuja.Value = Math.Min(progreso, 100);
                        lblBurbuja.Text = $"Burbuja: {progreso}%";
                    }));

                    // Tomamos una foto del estado actual
                    int step = Math.Max(1, n / snapshotCount);
                    if (i % step == 0) RecordSnapshot(listaBurbuja, snapshotsBurbuja);
                }
            }

            relojBurbuja.Stop();

            // Mostramos el resultado final
            this.Invoke(new Action(() =>
            {
                progressBurbuja.Value = 100;
                lblBurbuja.Text = $"Burbuja: {(cancelarBurbuja ? "Cancelado" : $"Completado en {relojBurbuja.ElapsedMilliseconds} ms")}";
                ActualizarChart("Bubble Sort", cancelarBurbuja ? -1 : (int)relojBurbuja.ElapsedMilliseconds);
            }));
        }

        // ===== ALGORITMO QUICKSORT =====
        // Es muy rápido en la práctica
        // Elige un "pivote" y reorganiza los elementos alrededor de él
        private void QuickSort(List<int> lista, int izquierda, int derecha, BackgroundWorker worker)
        {
            if (worker.CancellationPending) throw new OperationCanceledException();

            if (izquierda < derecha)
            {
                int pivot = Particionar(lista, izquierda, derecha, worker);
                QuickSort(lista, izquierda, pivot - 1, worker);
                QuickSort(lista, pivot + 1, derecha, worker);
            }
        }

        // Esta es la parte clave de QuickSort - la partición
        private int Particionar(List<int> lista, int izquierda, int derecha, BackgroundWorker worker)
        {
            if (worker.CancellationPending) throw new OperationCanceledException();

            int pivote = lista[derecha]; // Elegimos el último elemento como pivote
            int i = izquierda - 1;

            for (int j = izquierda; j < derecha; j++)
            {
                if (worker.CancellationPending) throw new OperationCanceledException();

                if (lista[j] <= pivote)
                {
                    i++;
                    // Intercambiamos elementos
                    int temp = lista[i];
                    lista[i] = lista[j];
                    lista[j] = temp;
                }
            }

            // Colocamos el pivote en su posición final
            int temp2 = lista[i + 1];
            lista[i + 1] = lista[derecha];
            lista[derecha] = temp2;

            // Contamos cuántos pivotes hemos colocado (para el progreso)
            int colocados = Interlocked.Increment(ref quickPivotesColocados);

            // Reportamos el progreso de forma inteligente:
            // Si la lista es grande, reportamos cada 1% de progreso
            // Si es pequeña, reportamos más frecuentemente
            int total = lista.Count;
            int reportEvery = Math.Max(1, total / 100);
            if (colocados % reportEvery == 0 || colocados == total)
            {
                int progreso = Math.Min(100, (int)((colocados / (float)total) * 100));
                try
                {
                    if (worker.WorkerReportsProgress) worker.ReportProgress(progreso);
                }
                catch { }

                // Tomamos una foto en momentos clave
                int stepQuick = Math.Max(1, total / snapshotCount);
                if (colocados % stepQuick == 0)
                {
                    RecordSnapshot(lista, snapshotsQuick);
                }
            }

            return i + 1;
        }

        // ===== EVENTOS DEL BACKGROUNDWORKER (QUICKSORT) =====

        // Este método se ejecuta en un hilo separado
        private void backgroundWorkerQuickSort_DoWork(object sender, DoWorkEventArgs e)
        {
            relojQuick.Restart();
            quickPivotesColocados = 0;
            List<int> lista = (List<int>)e.Argument;
            BackgroundWorker worker = sender as BackgroundWorker;

            try
            {
                QuickSort(lista, 0, lista.Count - 1, worker);
            }
            catch (OperationCanceledException)
            {
                // El usuario canceló la operación
                e.Cancel = true;
            }
            finally
            {
                relojQuick.Stop();
                e.Result = lista;
            }
        }

        // Se llama cuando QuickSort reporta progreso
        private void backgroundWorkerQuickSort_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressQuickSort.Value = e.ProgressPercentage;
            lblQuickSort.Text = $"QuickSort: {e.ProgressPercentage}%";
        }

        // Se llama cuando QuickSort termina (bien, con error o cancelado)
        private void backgroundWorkerQuickSort_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                lblQuickSort.Text = $"QuickSort: Cancelado";
                progressQuickSort.Value = Math.Min(progressQuickSort.Value, 100);
                ActualizarChart("QuickSort", -1);
            }
            else if (e.Error != null)
            {
                lblQuickSort.Text = $"QuickSort: Error ({e.Error.Message})";
                ActualizarChart("QuickSort", -1);
            }
            else
            {
                lblQuickSort.Text = $"QuickSort: Completado en {relojQuick.ElapsedMilliseconds} ms";
                progressQuickSort.Value = 100;
                ActualizarChart("QuickSort", (int)relojQuick.ElapsedMilliseconds);
            }
        }

        // ===== ALGORITMO MERGE SORT =====
        // Divide la lista en mitades, ordena cada mitad y luego las fusiona
        private void OrdenarMerge()
        {
            relojMerge.Restart();
            mergeProgresoContador = 0;
            try
            {
                MergeSort(listaMerge, 0, listaMerge.Count - 1);
            }
            catch (OperationCanceledException) { }
            relojMerge.Stop();

            this.Invoke(new Action(() =>
            {
                lblMerge.Text = $"Merge: {(cancelarMerge ? "Cancelado" : $"Completado en {relojMerge.ElapsedMilliseconds} ms")}";
                if (progressMerge != null) progressMerge.Value = 100;
                ActualizarChart("MergeSort", cancelarMerge ? -1 : (int)relojMerge.ElapsedMilliseconds);
            }));
        }

        private void MergeSort(List<int> arr, int l, int r)
        {
            if (cancelarMerge) throw new OperationCanceledException();
            if (l < r)
            {
                int m = (l + r) / 2;
                MergeSort(arr, l, m);
                if (cancelarMerge) throw new OperationCanceledException();
                MergeSort(arr, m + 1, r);
                if (cancelarMerge) throw new OperationCanceledException();
                Merge(arr, l, m, r);

                // Actualizamos el progreso cada 50 fusiones
                if (Interlocked.Increment(ref mergeProgresoContador) % 50 == 0)
                {
                    int prog = Math.Min(100, (int)((mergeProgresoContador / (float)arr.Count) * 100));
                    if (progressMerge != null && !cancelarMerge)
                        this.Invoke(new Action(() => {
                            progressMerge.Value = Math.Min(100, prog);
                            lblMerge.Text = $"Merge: {progressMerge.Value}%";
                        }));
                }
            }
        }

        // Fusiona dos mitades ordenadas en una sola lista ordenada
        private void Merge(List<int> arr, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;
            int[] L = new int[n1];
            int[] R = new int[n2];
            for (int i = 0; i < n1; ++i) L[i] = arr[l + i];
            for (int j = 0; j < n2; ++j) R[j] = arr[m + 1 + j];
            int ii = 0, jj = 0; int k = l;
            while (ii < n1 && jj < n2)
            {
                if (L[ii] <= R[jj]) { arr[k++] = L[ii++]; } else { arr[k++] = R[jj++]; }
            }
            while (ii < n1) arr[k++] = L[ii++];
            while (jj < n2) arr[k++] = R[jj++];

            // Tomamos una foto después de fusionar
            if (snapshotsMerge.Count < snapshotCount)
            {
                RecordSnapshot(arr, snapshotsMerge);
            }
        }

        // ===== ALGORITMO SELECTION SORT =====
        // Encuentra el elemento más pequeño y lo coloca al inicio
        private void OrdenarSelection()
        {
            relojSelection.Restart();
            int n = listaSelection.Count;
            for (int i = 0; i < n - 1; i++)
            {
                if (cancelarSelection) break;
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (cancelarSelection) break;
                    if (listaSelection[j] < listaSelection[min_idx]) min_idx = j;
                }
                int temp = listaSelection[min_idx];
                listaSelection[min_idx] = listaSelection[i];
                listaSelection[i] = temp;

                // Actualizamos progreso cada 100 iteraciones
                if (i % 100 == 0)
                {
                    int stepSel = Math.Max(1, n / snapshotCount);
                    if (i % stepSel == 0) RecordSnapshot(listaSelection, snapshotsSelection);

                    int progreso = (int)((i / (float)n) * 100);
                    if (progressSelection != null)
                    {
                        this.Invoke(new Action(() =>
                        {
                            progressSelection.Value = Math.Min(progreso, 100);
                            lblSelection.Text = $"Selection: {progreso}%";
                        }));
                    }
                }
            }
            relojSelection.Stop();
            this.Invoke(new Action(() =>
            {
                if (progressSelection != null) progressSelection.Value = 100;
                lblSelection.Text = $"Selection: {(cancelarSelection ? "Cancelado" : $"Completado en {relojSelection.ElapsedMilliseconds} ms")}";
                ActualizarChart("SelectionSort", cancelarSelection ? -1 : (int)relojSelection.ElapsedMilliseconds);
            }));
        }

        // ===== TOMAR FOTOS DEL PROCESO =====
        // Guarda el estado actual de la lista para poder analizarlo después
        private void RecordSnapshot(List<int> source, List<List<int>> target)
        {
            if (source == null || target == null) return;
            lock (target) // lock evita que dos hilos modifiquen al mismo tiempo
            {
                if (target.Count >= snapshotCount) return;

                // Solo guardamos los primeros 200 elementos para no usar mucha memoria
                if (source.Count <= 200)
                    target.Add(new List<int>(source));
                else
                    target.Add(new List<int>(source.Take(200)));
            }
        }

        // ===== ACTUALIZAR EL GRÁFICO =====
        // Muestra los tiempos de cada algoritmo en un gráfico de barras
        private void ActualizarChart(string nombre, int ms)
        {
            if (chartResultados == null) return;

            // Si estamos en un hilo que no es el de la UI, usamos Invoke
            if (chartResultados.InvokeRequired)
            {
                chartResultados.Invoke(new Action(() => ActualizarChart(nombre, ms)));
                return;
            }

            string seriePrincipal = "Tiempos";

            // Buscamos la serie en el gráfico
            Series s = null;
            foreach (Series sr in chartResultados.Series)
            {
                if (sr.Name == seriePrincipal) { s = sr; break; }
            }

            // Si no existe, la creamos
            if (s == null)
            {
                s = new Series(seriePrincipal);
                s.ChartType = SeriesChartType.Column;
                chartResultados.Series.Add(s);

                if (chartResultados.ChartAreas.Count == 0)
                    chartResultados.ChartAreas.Add(new ChartArea("Default"));
                s.ChartArea = chartResultados.ChartAreas[0].Name;
            }

            // Buscamos si ya existe una barra para este algoritmo
            int idx = -1;
            for (int i = 0; i < s.Points.Count; i++)
            {
                if (s.Points[i].AxisLabel == nombre) { idx = i; break; }
            }
            if (idx >= 0) s.Points.RemoveAt(idx);

            // Agregamos la nueva barra
            if (ms >= 0)
            {
                var p = s.Points.Add(ms);
                p.AxisLabel = nombre;
            }
            else
            {
                var p = s.Points.Add(0);
                p.AxisLabel = nombre + " (cancelado)";
            }
        }

        // ===== GUARDAR RESULTADOS EN WORD =====
        private void btnGuardarResultados_Click(object sender, EventArgs e)
        {
            GuardarResultadosWord();
        }

        private void GuardarResultadosWord()
        {
            if (listaOriginal == null || listaOriginal.Count == 0)
            {
                MessageBox.Show("Primero genera los datos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // No generamos Word para listas muy grandes porque sería muy lento
            const int maxElementsToAllowDoc = 1000;
            if (listaOriginal.Count > maxElementsToAllowDoc)
            {
                MessageBox.Show(
                    $"La lista tiene {listaOriginal.Count} elementos. No se generará un documento Word porque supera el límite de {maxElementsToAllowDoc} elementos.",
                    "Límite excedido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            var algoritmos = new[]
            {
                new { Name = "Bubble Sort", List = listaBurbuja, Snapshots = snapshotsBurbuja },
                new { Name = "QuickSort", List = listaQuick, Snapshots = snapshotsQuick },
                new { Name = "MergeSort", List = listaMerge, Snapshots = snapshotsMerge },
                new { Name = "SelectionSort", List = listaSelection, Snapshots = snapshotsSelection }
            };

            // Creamos una carpeta en el Escritorio llamada SAVES
            string destFolder = System.IO.Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "SAVES"
            );
            System.IO.Directory.CreateDirectory(destFolder);

            string timeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            // Generamos un documento Word para cada algoritmo
            foreach (var alg in algoritmos)
            {
                Word.Application wordApp = null;
                Word.Document doc = null;
                try
                {
                    wordApp = new Word.Application();
                    wordApp.Visible = false; // No mostramos Word (solo generamos el archivo)
                    doc = wordApp.Documents.Add();

                    // Escribimos el contenido del documento:
                    // - Título y información general
                    // - Tabla de tiempos comparativos
                    // - Lista original
                    // - Fotos del proceso (snapshots)
                    // - Lista ordenada final

                    var titlePara = doc.Paragraphs.Add();
                    titlePara.Range.Text = $"RESULTADOS - {alg.Name}";
                    titlePara.Range.Font.Bold = 1;
                    titlePara.Range.Font.Size = 16;
                    titlePara.Format.SpaceAfter = 12;
                    titlePara.Range.InsertParagraphAfter();

                    var infoPara = doc.Paragraphs.Add();
                    infoPara.Range.Text = $"Fecha ejecución: {DateTime.Now}\nElementos totales (original): {listaOriginal?.Count ?? 0}\n";
                    infoPara.Range.Font.Size = 12;
                    infoPara.Range.InsertParagraphAfter();

                    // Tabla que muestra los tiempos de todos los algoritmos
                    var tableTitle = doc.Paragraphs.Add();
                    tableTitle.Range.Text = "\nTabla de tiempos (ms):";
                    tableTitle.Range.Font.Bold = 1;
                    tableTitle.Range.InsertParagraphAfter();

                    Word.Table tiemposTable = doc.Tables.Add(doc.Paragraphs.Add().Range, 5, 2);
                    tiemposTable.Borders.Enable = 1;
                    tiemposTable.Rows[1].Cells[1].Range.Text = "Algoritmo";
                    tiemposTable.Rows[1].Cells[2].Range.Text = "Tiempo (ms) / Estado";

                    string[] names = { "Bubble Sort", "QuickSort", "MergeSort", "SelectionSort" };
                    for (int r = 0; r < names.Length; r++)
                    {
                        tiemposTable.Rows[r + 2].Cells[1].Range.Text = names[r];
                        tiemposTable.Rows[r + 2].Cells[2].Range.Text = ObtenerTiempoAlgoritmo(names[r]);
                    }
                    tiemposTable.Range.InsertParagraphAfter();

                    // Mostramos la lista original (desordenada)
                    Word.Paragraph unsortedHeader = doc.Paragraphs.Add();
                    unsortedHeader.Range.Text = "\nLista desordenada (original):";
                    unsortedHeader.Range.Font.Bold = 1;
                    unsortedHeader.Range.InsertParagraphAfter();

                    var original = listaOriginal ?? new List<int>();
                    Word.Paragraph unsortedPara = doc.Paragraphs.Add();
                    unsortedPara.Range.Text = string.Join(", ", original);
                    unsortedPara.Range.InsertParagraphAfter();

                    // Mostramos las fotos del proceso
                    Word.Paragraph progHeader = doc.Paragraphs.Add();
                    progHeader.Range.Text = "\nProgresión (snapshots):";
                    progHeader.Range.Font.Bold = 1;
                    progHeader.Range.InsertParagraphAfter();

                    var snaps = alg.Snapshots;
                    if (snaps == null || snaps.Count == 0)
                    {
                        Word.Paragraph noSnapPara = doc.Paragraphs.Add();
                        noSnapPara.Range.Text = "No se tomaron snapshots durante la ordenación.";
                        noSnapPara.Range.InsertParagraphAfter();
                    }
                    else
                    {
                        for (int i = 0; i < snaps.Count; i++)
                        {
                            var snap = snaps[i];
                            Word.Paragraph sPara = doc.Paragraphs.Add();
                            int porcentajeAprox = (int)((i / (float)Math.Max(1, snaps.Count - 1)) * 100);
                            sPara.Range.Text = $"Snapshot {i + 1}/{snaps.Count} (~{porcentajeAprox}%):";
                            sPara.Range.Font.Bold = 0;
                            sPara.Range.InsertParagraphAfter();

                            Word.Paragraph snapPara = doc.Paragraphs.Add();
                            snapPara.Range.Text = string.Join(", ", snap);
                            snapPara.Range.InsertParagraphAfter();
                        }
                    }

                    // Mostramos la lista final ordenada
                    Word.Paragraph finalHeader = doc.Paragraphs.Add();
                    finalHeader.Range.Text = "\nLista final ordenada:";
                    finalHeader.Range.Font.Bold = 1;
                    finalHeader.Range.InsertParagraphAfter();

                    var sorted = alg.List ?? new List<int>();
                    Word.Paragraph finalPara = doc.Paragraphs.Add();
                    finalPara.Range.Text = string.Join(", ", sorted);
                    finalPara.Range.InsertParagraphAfter();

                    // Guardamos el documento
                    string ruta = System.IO.Path.Combine(destFolder, $"{alg.Name}_Resultados_{timeStamp}.docx");
                    doc.SaveAs2(ruta);

                    MessageBox.Show($"Documento guardado: {ruta}", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al generar doc de {alg.Name}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    try { LiberarRecursosWord(wordApp, doc); } catch { }
                }
            }
        }

        // Obtiene el tiempo de ejecución de cada algoritmo
        private string ObtenerTiempoAlgoritmo(string algoritmo)
        {
            switch (algoritmo)
            {
                case "Bubble Sort":
                    return cancelarBurbuja ? "Cancelado" : $"{relojBurbuja.ElapsedMilliseconds} ms";
                case "QuickSort":
                    return backgroundWorkerQuickSort.CancellationPending ? "Cancelado" : $"{relojQuick.ElapsedMilliseconds} ms";
                case "MergeSort":
                    return cancelarMerge ? "Cancelado" : $"{relojMerge.ElapsedMilliseconds} ms";
                case "SelectionSort":
                    return cancelarSelection ? "Cancelado" : $"{relojSelection.ElapsedMilliseconds} ms";
                default:
                    return "N/A";
            }
        }

        // Cierra Word y libera los recursos
        private void LiberarRecursosWord(Word.Application wordApp, Word.Document doc)
        {
            try
            {
                if (doc != null)
                {
                    doc.Close(SaveChanges: false);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);
                }
                if (wordApp != null)
                {
                    wordApp.Quit(SaveChanges: false);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error liberando recursos Word: " + ex.Message);
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        // ===== AL CERRAR LA APLICACIÓN =====
        // Nos aseguramos de detener todos los hilos
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            cancelarBurbuja = true;
            cancelarMerge = true;
            cancelarSelection = true;
            if (backgroundWorkerQuickSort.IsBusy) backgroundWorkerQuickSort.CancelAsync();
            base.OnFormClosing(e);
        }

        private void btnGuardarResultados_Click_1(object sender, EventArgs e)
        {
            GuardarResultadosWord();
        }
    }
}