namespace PCADM
{
    partial class RDPPForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            RoyalApps.Community.Rdp.WinForms.Configuration.RdpClientConfiguration rdpClientConfiguration1 = new RoyalApps.Community.Rdp.WinForms.Configuration.RdpClientConfiguration();
            RoyalApps.Community.Rdp.WinForms.Configuration.ConnectionConfiguration connectionConfiguration1 = new RoyalApps.Community.Rdp.WinForms.Configuration.ConnectionConfiguration();
            RoyalApps.Community.Rdp.WinForms.Configuration.CredentialConfiguration credentialConfiguration1 = new RoyalApps.Community.Rdp.WinForms.Configuration.CredentialConfiguration();
            RoyalApps.Community.Rdp.WinForms.Configuration.DisplayConfiguration displayConfiguration1 = new RoyalApps.Community.Rdp.WinForms.Configuration.DisplayConfiguration();
            RoyalApps.Community.Rdp.WinForms.Configuration.GatewayConfiguration gatewayConfiguration1 = new RoyalApps.Community.Rdp.WinForms.Configuration.GatewayConfiguration();
            RoyalApps.Community.Rdp.WinForms.Configuration.HyperVConfiguration hypervConfiguration1 = new RoyalApps.Community.Rdp.WinForms.Configuration.HyperVConfiguration();
            RoyalApps.Community.Rdp.WinForms.Configuration.InputConfiguration inputConfiguration1 = new RoyalApps.Community.Rdp.WinForms.Configuration.InputConfiguration();
            RoyalApps.Community.Rdp.WinForms.Configuration.PerformanceConfiguration performanceConfiguration1 = new RoyalApps.Community.Rdp.WinForms.Configuration.PerformanceConfiguration();
            RoyalApps.Community.Rdp.WinForms.Configuration.ProgramConfiguration programConfiguration1 = new RoyalApps.Community.Rdp.WinForms.Configuration.ProgramConfiguration();
            RoyalApps.Community.Rdp.WinForms.Configuration.RedirectionConfiguration redirectionConfiguration1 = new RoyalApps.Community.Rdp.WinForms.Configuration.RedirectionConfiguration();
            RoyalApps.Community.Rdp.WinForms.Configuration.SecurityConfiguration securityConfiguration1 = new RoyalApps.Community.Rdp.WinForms.Configuration.SecurityConfiguration();
            axMsRdpClient91 = new RoyalApps.Community.Rdp.WinForms.Controls.RdpControl();
            SuspendLayout();
            // 
            // axMsRdpClient91
            // 
            axMsRdpClient91.Location = new Point(1, 2);
            axMsRdpClient91.Name = "axMsRdpClient91";
            rdpClientConfiguration1.ClientVersion = 0;
            connectionConfiguration1.Compression = false;
            connectionConfiguration1.ConnectionKeepAliveInterval = null;
            connectionConfiguration1.DisableUdpTransport = false;
            connectionConfiguration1.EnableAutoReconnect = false;
            connectionConfiguration1.EnableRdsAadAuth = false;
            connectionConfiguration1.KeepAlive = false;
            connectionConfiguration1.KeepAliveInterval = 60;
            connectionConfiguration1.KeepAliveMethod = RoyalApps.Community.Rdp.WinForms.Configuration.KeepAliveMethod.MouseMove;
            connectionConfiguration1.LoadBalanceInfo = null;
            connectionConfiguration1.MaxReconnectAttempts = 0;
            connectionConfiguration1.UseRedirectionServerName = false;
            rdpClientConfiguration1.Connection = connectionConfiguration1;
            credentialConfiguration1.Domain = null;
            credentialConfiguration1.NetworkLevelAuthentication = false;
            credentialConfiguration1.Password = null;
            credentialConfiguration1.PasswordContainsSmartCardPin = false;
            credentialConfiguration1.Username = null;
            rdpClientConfiguration1.Credentials = credentialConfiguration1;
            displayConfiguration1.AutoScaling = true;
            displayConfiguration1.ColorDepth = RoyalApps.Community.Rdp.WinForms.Configuration.ColorDepth.ColorDepth32Bpp;
            displayConfiguration1.ContainerHandledFullScreen = true;
            displayConfiguration1.DesktopHeight = 0;
            displayConfiguration1.DesktopWidth = 0;
            displayConfiguration1.DisplayConnectionBar = true;
            displayConfiguration1.FullScreen = false;
            displayConfiguration1.FullScreenTitle = null;
            displayConfiguration1.InitialZoomLevel = 100;
            displayConfiguration1.PinConnectionBar = false;
            displayConfiguration1.ResizeBehavior = RoyalApps.Community.Rdp.WinForms.Configuration.ResizeBehavior.SmartReconnect;
            displayConfiguration1.UseLocalScaling = false;
            displayConfiguration1.UseMultimon = false;
            rdpClientConfiguration1.Display = displayConfiguration1;
            gatewayConfiguration1.GatewayCredSharing = false;
            gatewayConfiguration1.GatewayCredsSource = RoyalApps.Community.Rdp.WinForms.Configuration.GatewayCredentialSource.UsernameAndPassword;
            gatewayConfiguration1.GatewayDomain = null;
            gatewayConfiguration1.GatewayHostname = null;
            gatewayConfiguration1.GatewayPassword = null;
            gatewayConfiguration1.GatewayProfileUsageMethod = RoyalApps.Community.Rdp.WinForms.Configuration.GatewayProfileUsageMethod.Default;
            gatewayConfiguration1.GatewayUsageMethod = RoyalApps.Community.Rdp.WinForms.Configuration.GatewayUsageMethod.Never;
            gatewayConfiguration1.GatewayUsername = null;
            gatewayConfiguration1.GatewayUserSelectedCredsSource = RoyalApps.Community.Rdp.WinForms.Configuration.GatewayCredentialSource.UsernameAndPassword;
            rdpClientConfiguration1.Gateway = gatewayConfiguration1;
            hypervConfiguration1.EnhancedSessionMode = false;
            hypervConfiguration1.HyperVPort = 2179;
            hypervConfiguration1.Instance = null;
            rdpClientConfiguration1.HyperV = hypervConfiguration1;
            inputConfiguration1.AcceleratorPassthrough = false;
            inputConfiguration1.AllowBackgroundInput = false;
            inputConfiguration1.DisableClickDetection = false;
            inputConfiguration1.EnableWindowsKey = false;
            inputConfiguration1.GrabFocusOnConnect = false;
            inputConfiguration1.KeyboardHookMode = false;
            inputConfiguration1.KeyBoardLayoutStr = null;
            inputConfiguration1.RelativeMouseMode = true;
            rdpClientConfiguration1.Input = inputConfiguration1;
            rdpClientConfiguration1.LogEnabled = false;
            rdpClientConfiguration1.LogFilePath = "C:\\Users\\ALX\\AppData\\Local\\Temp\\MsRdpEx.log";
            rdpClientConfiguration1.LogLevel = "TRACE";
            rdpClientConfiguration1.MsRdcPath = null;
            performanceConfiguration1.BandwidthDetection = false;
            performanceConfiguration1.BitmapCaching = false;
            performanceConfiguration1.ClientProtocolSpec = RoyalApps.Community.Rdp.WinForms.Configuration.ClientProtocolSpec.FullMode;
            performanceConfiguration1.DisableCursorSettings = false;
            performanceConfiguration1.DisableCursorShadow = false;
            performanceConfiguration1.DisableFullWindowDrag = false;
            performanceConfiguration1.DisableMenuAnimations = false;
            performanceConfiguration1.DisableTheming = false;
            performanceConfiguration1.DisableWallpaper = false;
            performanceConfiguration1.EnableDesktopComposition = false;
            performanceConfiguration1.EnableEnhancedGraphics = false;
            performanceConfiguration1.EnableFontSmoothing = false;
            performanceConfiguration1.EnableHardwareMode = false;
            performanceConfiguration1.NetworkConnectionType = RoyalApps.Community.Rdp.WinForms.Configuration.NetworkConnectionType.BroadbandHigh;
            performanceConfiguration1.RedirectDirectX = false;
            rdpClientConfiguration1.Performance = performanceConfiguration1;
            rdpClientConfiguration1.PluginDlls = null;
            rdpClientConfiguration1.Port = 3389;
            programConfiguration1.MaximizeShell = true;
            programConfiguration1.StartProgram = null;
            programConfiguration1.WorkDir = null;
            rdpClientConfiguration1.Program = programConfiguration1;
            redirectionConfiguration1.AudioCaptureRedirectionMode = false;
            redirectionConfiguration1.AudioQualityMode = RoyalApps.Community.Rdp.WinForms.Configuration.AudioQualityMode.Dynamic;
            redirectionConfiguration1.AudioRedirectionMode = RoyalApps.Community.Rdp.WinForms.Configuration.AudioRedirectionMode.RedirectToClient;
            redirectionConfiguration1.RedirectCameras = false;
            redirectionConfiguration1.RedirectClipboard = false;
            redirectionConfiguration1.RedirectDevices = false;
            redirectionConfiguration1.RedirectDriveLetters = null;
            redirectionConfiguration1.RedirectDrives = false;
            redirectionConfiguration1.RedirectLocation = false;
            redirectionConfiguration1.RedirectPointOfServiceDevices = false;
            redirectionConfiguration1.RedirectPorts = false;
            redirectionConfiguration1.RedirectPrinters = false;
            redirectionConfiguration1.RedirectSmartCards = false;
            redirectionConfiguration1.RedirectVideoRendering = false;
            rdpClientConfiguration1.Redirection = redirectionConfiguration1;
            securityConfiguration1.AuthenticationLevel = RoyalApps.Community.Rdp.WinForms.Configuration.AuthenticationLevel.NoAuthenticationOfServer;
            securityConfiguration1.ConnectToAdministerServer = false;
            securityConfiguration1.PublicMode = false;
            securityConfiguration1.RemoteCredentialGuard = false;
            securityConfiguration1.RestrictedAdminMode = false;
            rdpClientConfiguration1.Security = securityConfiguration1;
            rdpClientConfiguration1.Server = null;
            rdpClientConfiguration1.UseMsRdc = false;
            axMsRdpClient91.RdpConfiguration = rdpClientConfiguration1;
            axMsRdpClient91.Size = new Size(787, 446);
            axMsRdpClient91.TabIndex = 0;
            // 
            // RDPPForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(axMsRdpClient91);
            Name = "RDPPForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "RDP";
            ResumeLayout(false);
        }

        #endregion

        private RoyalApps.Community.Rdp.WinForms.Controls.RdpControl axMsRdpClient91;
    }
}