using NAudio.Wave;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;

namespace audio_file_converter
{
    public partial class AudioFileConverter : Form
    {
        private bool mIsDeleteInputeFiles;
        private ExportFileNameExtension mSelectedExportExtension;

        private static readonly string[] ALLOW_IMPORT_EXTENSIONS = new string[] { ".mp3", ".wav", ".aac" };

        private static readonly Dictionary<ExportFileNameExtension, string> EXPORT_EXTENSIONS = new Dictionary<ExportFileNameExtension, string>()
        {
            { ExportFileNameExtension.MP3, ".mp3" },
            { ExportFileNameExtension.WAV, ".wav" },
            { ExportFileNameExtension.AAC, ".aac" },
        };


        enum ExportFileNameExtension
        {
            MP3,
            WAV,
            AAC
        }

        public AudioFileConverter()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            this.TopMost = AlwaysOnTopCheckBox.Checked;
            mIsDeleteInputeFiles = false;
            mSelectedExportExtension = ExportFileNameExtension.MP3;
        }

        private MediaFoundationReader OpenInputFile(string fileName)
        {
            MediaFoundationReader reader = null;

            try
            {
                reader = new MediaFoundationReader(fileName);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Not a supported input file: {fileName}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.Error.WriteLine(e.Message);
            }

            return reader;
        }

        private bool ConvertAndExportFile(MediaFoundationReader reader, string inputFileName)
        {
            string inputFileExtension = Path.GetExtension(inputFileName).ToLower();
            string outputFileName = GetPathWithoutExtension(inputFileName);

            // 変換前の拡張子と同じ場合は以降の処理はしない
            if (inputFileExtension == EXPORT_EXTENSIONS[mSelectedExportExtension])
            {
                return false;
            }

            switch (mSelectedExportExtension)
            {
                case ExportFileNameExtension.MP3:
                    try
                    {
                        MediaFoundationEncoder.EncodeToMp3(reader, outputFileName + EXPORT_EXTENSIONS[ExportFileNameExtension.MP3]);
                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show($"Failed to convert a input file: {inputFileName}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Console.Error.WriteLine(ex.Message);
                        return false;
                    }
                    break;
                case ExportFileNameExtension.WAV:
                    try
                    {
                        WaveFileWriter.CreateWaveFile(outputFileName + EXPORT_EXTENSIONS[ExportFileNameExtension.WAV], reader);
                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show($"Failed to convert a input file: {inputFileName}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Console.Error.WriteLine(ex.Message);
                        return false;
                    }
                    break;
                case ExportFileNameExtension.AAC:
                    try
                    {
                        MediaFoundationEncoder.EncodeToAac(reader, outputFileName + EXPORT_EXTENSIONS[ExportFileNameExtension.AAC]);
                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show($"Failed to convert a input file: {inputFileName}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Console.Error.WriteLine(ex.Message);
                        return false;
                    }
                    break;
                default:
                    break;

            }

            return true;
        }

        private string GetPathWithoutExtension(string path)
        {
            string extension = Path.GetExtension(path);
            return path.Replace(extension, string.Empty);
        }

        private void StartProgressBar()
        {
            ProgressBar.Style = ProgressBarStyle.Marquee;
        }

        private void StopProgressBar()
        {
            ProgressBar.Style = ProgressBarStyle.Continuous;
        }

        private async void SelectInputFileButton_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Multiselect = true;

            string filter = "Autdio files|";
            foreach (string extension in ALLOW_IMPORT_EXTENSIONS)
            {
                filter = filter + "*" + extension + ";";
            }
            ofd.Filter = filter;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.Enabled = false;
                StartProgressBar();

                await Task.Run(() =>
                {
                    foreach (string inputFileName in ofd.FileNames)
                    {
                        // 変換対象のファイル読み込む
                        MediaFoundationReader reader = OpenInputFile(inputFileName);

                        if (reader != null)
                        {
                            // 指定した拡張子に変換後、変換対象と同じ場所に出力
                            bool res = ConvertAndExportFile(reader, inputFileName);

                            if (res && mIsDeleteInputeFiles)
                            {
                                // ファイルをゴミ箱へ移動
                                FileSystem.DeleteFile(inputFileName, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                            }

                        }
                    }
                });

                StopProgressBar();
                this.Enabled = true;
            }
        }

        private void DeleteInputFilesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            mIsDeleteInputeFiles = DeleteInputFilesCheckBox.Checked;
        }

        private void AlwaysOnTopCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = AlwaysOnTopCheckBox.Checked;
        }

        private void ExsitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MP3RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            mSelectedExportExtension = ExportFileNameExtension.MP3;
        }

        private void WAVRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            mSelectedExportExtension = ExportFileNameExtension.WAV;
        }

        private void AACRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            mSelectedExportExtension = ExportFileNameExtension.AAC;
        }

        private bool checkExtension(string fileName)
        {
            bool isValied = false;
            string extension = Path.GetExtension(fileName).ToLower();

            if (Array.IndexOf(ALLOW_IMPORT_EXTENSIONS, extension) != -1)
            {
                isValied = true;
            }

            return isValied;
        }

        private async void AudioFileConverter_DragDrop(object sender, DragEventArgs e)
        {
            this.Enabled = false;
            StartProgressBar();

            // ドラッグ＆ドロップしたファイルフォルダのパスを取得
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            // ファイルフォルダかを確認
            bool isFolder = File.GetAttributes(files[0]).HasFlag(FileAttributes.Directory);
            if (isFolder)
            {
                // ディレクトリ以下にあるすべてのファイルを取得
                var fsEntries = Directory.EnumerateFileSystemEntries(files[0], "*.*", System.IO.SearchOption.AllDirectories);

                await Task.Run(() =>
                {
                    foreach (string entry in fsEntries)
                    {
                        if (checkExtension(entry))
                        {
                            // 変換対象のファイル読み込む
                            MediaFoundationReader reader = OpenInputFile(entry);

                            if (reader != null)
                            {
                                // 指定した拡張子に変換後、変換対象と同じ場所に出力
                                bool res = ConvertAndExportFile(reader, entry);

                                if (res && mIsDeleteInputeFiles)
                                {
                                    // ファイルをゴミ箱へ移動
                                    FileSystem.DeleteFile(entry, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                                }

                            }
                        }
                    }
                });
            }
            else // ファイル単体またはファイル複数の場合
            {
                this.Enabled = false;
                StartProgressBar();

                await Task.Run(() =>
                {
                    foreach (string file in files)
                    {
                        if (checkExtension(file))
                        {
                            // 変換対象のファイル読み込む
                            MediaFoundationReader reader = OpenInputFile(file);

                            if (reader != null)
                            {
                                // 指定した拡張子に変換後、変換対象と同じ場所に出力
                                bool res = ConvertAndExportFile(reader, file);

                                if (res && mIsDeleteInputeFiles)
                                {
                                    // ファイルをゴミ箱へ移動
                                    FileSystem.DeleteFile(file, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                                }
                            }
                        }
                        else
                        {

                            MessageBox.Show($"Not a supported input file: {file[0]}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                });

                StopProgressBar();
                this.Enabled = true;
            }
        }

        private void AudioFileConverter_DragEnter(object sender, DragEventArgs e)
        {
            // マウスポインター形状変更
            //
            //  DragDropEffects
            //  Copy  :データがドロップ先にコピーされようとしている状態
            //  Move  :データがドロップ先に移動されようとしている状態
            //  Scroll:データによってドロップ先でスクロールが開始されようとしている状態、あるいは現在スクロール中である状態
            //  All   :上の3つを組み合わせたもの
            //  Link  :データのリンクがドロップ先に作成されようとしている状態
            //  None  :いかなるデータもドロップ先が受け付けようとしない状態
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}
