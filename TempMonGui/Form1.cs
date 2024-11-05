using LibreHardwareMonitor.Hardware;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;

namespace HardwareMonitorApp
{
    public partial class Form1 : Form
    {
        #region Fields and Properties

        private Computer _computer;
        private NotifyIcon _trayIcon;
        private bool _dragging = false;
        private Point _dragCursorPoint;
        private Point _dragFormPoint;
        private const string StartupKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        private const string StartupValue = "HardwareMonitor";

        #endregion

        #region Constructor and Initialization

        public Form1()
        {
            InitializeComponent();
            InitializeForm();
            InitializeHardwareMonitor();
            InitializeTrayIcon();
            InitializeTimer();
        }

        private void InitializeForm()
        {
            FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, Height, Height));
            TopMost = true;
            ShowInTaskbar = false;
        }
        
        private void InitializeTimer()
        {
            Timer timer = new Timer
            {
                Interval = 5000 // 5 second interval, 1000 = 1s 5000 = 5s etc
            };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        #endregion

        #region Hardware Monitoring

        private void InitializeHardwareMonitor()
        {
            try
            {
                // To add more sensors
                _computer = new Computer
                {
                    IsCpuEnabled = true,
                    IsGpuEnabled = true,
                    IsMemoryEnabled = true,
                 
                };
                _computer.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing TempMon: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateHardwareData()
        {
            if (_computer == null) return;

            bool cpuTemperatureFound = false;
            bool gpuTemperatureFound = false;
            bool ramUsageFound = false;

            foreach (var hardwareItem in _computer.Hardware)
            {
                try
                {
                    hardwareItem.Update();

                    switch (hardwareItem.HardwareType)
                    {
                        case HardwareType.Cpu:
                            UpdateCpuData(hardwareItem, ref cpuTemperatureFound);
                            break;
                        case HardwareType.GpuAmd:
                        case HardwareType.GpuNvidia:
                            UpdateGpuData(hardwareItem, ref gpuTemperatureFound);
                            break;
                        case HardwareType.Memory:
                            UpdateRamData(hardwareItem, ref ramUsageFound);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating {hardwareItem.HardwareType}: {ex.Message}");
                }
            }

            if (!cpuTemperatureFound) lblCPUTemperature.Text = "N/A";
            if (!gpuTemperatureFound) lblGPUTemperature.Text = "N/A";
            if (!ramUsageFound) lblRAMUsage.Text = "N/A";
        }

        private void UpdateRamData(IHardware hardwareItem, ref bool ramUsageFound)
        {
            foreach (var sensor in hardwareItem.Sensors)
            {
                if (sensor.SensorType == SensorType.Load && sensor.Name.Contains("Memory"))
                {
                    lblRAMUsage.Text = $"{Math.Round(sensor.Value.GetValueOrDefault(), 1)}%";
                    ramUsageFound = true;
                }
            }
        }


        private void UpdateCpuData(IHardware hardwareItem, ref bool cpuTemperatureFound)
        {
            foreach (var sensor in hardwareItem.Sensors)
            {
                if (sensor.SensorType == SensorType.Temperature && sensor.Name.Contains("CPU Package"))
                {
                    lblCPUTemperature.Text = $"{Math.Round(sensor.Value.GetValueOrDefault(), 2)}°C";
                    cpuTemperatureFound = true;
                }
                else if (sensor.SensorType == SensorType.Load && sensor.Name.Contains("CPU Total"))
                {
                    lblCPUUsage.Text = $"{Math.Round(sensor.Value.GetValueOrDefault(), 1)}%";
                }
            }
        }

        private void UpdateGpuData(IHardware hardwareItem, ref bool gpuTemperatureFound)
        {
            foreach (var sensor in hardwareItem.Sensors)
            {
                if (sensor.SensorType == SensorType.Temperature && sensor.Name.Contains("GPU Core"))
                {
                    lblGPUTemperature.Text = $"{Math.Round(sensor.Value.GetValueOrDefault(), 2)}°C";
                    gpuTemperatureFound = true;
                }
                else if (sensor.SensorType == SensorType.Load && sensor.Name.Contains("GPU Core"))
                {
                    lblGPUUsage.Text = $"{Math.Round(sensor.Value.GetValueOrDefault(), 1)}%";
                }
            }
        }

        #endregion

        #region Tray Icon and Menu

        private void InitializeTrayIcon()
        {
            _trayIcon = new NotifyIcon
            {
                Icon = new Icon("ico.ico"),
                Visible = true
            };
            
            _trayIcon.DoubleClick += TrayIcon_DoubleClick;

            ContextMenuStrip trayMenu = new ContextMenuStrip();
            trayMenu.Items.Add("Minimize", null, MinimizeForm_Click);
            trayMenu.Items.Add("Change Font", null, ChangeFont_Click);
            ToolStripMenuItem startupMenuItem = new ToolStripMenuItem("Run at Startup");
            startupMenuItem.Checked = IsStartupEnabled();
            startupMenuItem.Click += StartupMenuItem_Click;
            trayMenu.Items.Add(startupMenuItem);
            trayMenu.Items.Add("Exit", null, Exit_Click);
            _trayIcon.ContextMenuStrip = trayMenu;
        }
        private bool IsStartupEnabled()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(StartupKey))
            {
                return key?.GetValue(StartupValue) != null;
            }
        }

        private void StartupMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            if (menuItem == null) return;

            try
            {
                if (menuItem.Checked)
                {
                    // Remove from startup
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(StartupKey, true))
                    {
                        if (key != null)
                        {
                            key.DeleteValue(StartupValue, false);
                            menuItem.Checked = false;
                        }
                    }
                }
                else
                {
                    // Add to startup
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(StartupKey, true))
                    {
                        if (key != null)
                        {
                            string appPath = Application.ExecutablePath;
                            key.SetValue(StartupValue, appPath);
                            menuItem.Checked = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error modifying startup settings: {ex.Message}",
                              "Startup Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }
        private void TrayIcon_DoubleClick(object sender, EventArgs e) => ShowForm();
        private void ShowForm_Click(object sender, EventArgs e) => ShowForm();
        private void MinimizeForm_Click(object sender, EventArgs e) => MinimizeForm();

        private void ShowForm()
        {
            Show();
            WindowState = FormWindowState.Normal;
            Activate();
        }

        private void MinimizeForm()
        {
            Hide();
            WindowState = FormWindowState.Minimized;
        }

        private void ChangeFont_Click(object sender, EventArgs e)
        {
            using (FontDialog fontDialog = new FontDialog())
            {
                fontDialog.Font = Font;
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    ApplyFontToControls(this, fontDialog.Font);
                }
            }
        }

        private void ApplyFontToControls(Control control, Font font)
        {
            control.Font = font;
            foreach (Control child in control.Controls)
            {
                ApplyFontToControls(child, font);
            }
        }

        private void Exit_Click(object sender, EventArgs e) => Application.Exit();

        #endregion

        #region Form Events

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _dragCursorPoint = Cursor.Position;
            _dragFormPoint = Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(_dragCursorPoint));
                Location = Point.Add(_dragFormPoint, new Size(diff));
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e) => _dragging = false;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _computer?.Close();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                UpdateHardwareData();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating hardware data: {ex.Message}");
                UpdateUIWithErrorState();
            }
        }

        #endregion

        #region Helper Methods

        private void UpdateUIWithErrorState()
        {
            lblCPUTemperature.Text = "Error";
            lblCPUUsage.Text = "Error";
            lblGPUTemperature.Text = "Error";
            lblGPUUsage.Text = "Error";
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        #endregion
        
    }
}