namespace PCADM
{
    partial class RDPP
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
            RoyalApps.Community.Rdp.WinForms.Configuration.RdpClientConfiguration rdpClientConfiguration2 = new RoyalApps.Community.Rdp.WinForms.Configuration.RdpClientConfiguration();
            RoyalApps.Community.Rdp.WinForms.Configuration.ConnectionConfiguration connectionConfiguration2 = new RoyalApps.Community.Rdp.WinForms.Configuration.ConnectionConfiguration();
            RoyalApps.Community.Rdp.WinForms.Configuration.CredentialConfiguration credentialConfiguration2 = new RoyalApps.Community.Rdp.WinForms.Configuration.CredentialConfiguration();
            RoyalApps.Community.Rdp.WinForms.Configuration.DisplayConfiguration displayConfiguration2 = new RoyalApps.Community.Rdp.WinForms.Configuration.DisplayConfiguration();
            RoyalApps.Community.Rdp.WinForms.Configuration.GatewayConfiguration gatewayConfiguration2 = new RoyalApps.Community.Rdp.WinForms.Configuration.GatewayConfiguration();
            RoyalApps.Community.Rdp.WinForms.Configuration.HyperVConfiguration hypervConfiguration2 = new RoyalApps.Community.Rdp.WinForms.Configuration.HyperVConfiguration();
            RoyalApps.Community.Rdp.WinForms.Configuration.InputConfiguration inputConfiguration2 = new RoyalApps.Community.Rdp.WinForms.Configuration.InputConfiguration();
            RoyalApps.Community.Rdp.WinForms.Configuration.PerformanceConfiguration performanceConfiguration2 = new RoyalApps.Community.Rdp.WinForms.Configuration.PerformanceConfiguration();
            RoyalApps.Community.Rdp.WinForms.Configuration.ProgramConfiguration programConfiguration2 = new RoyalApps.Community.Rdp.WinForms.Configuration.ProgramConfiguration();
            RoyalApps.Community.Rdp.WinForms.Configuration.RedirectionConfiguration redirectionConfiguration2 = new RoyalApps.Community.Rdp.WinForms.Configuration.RedirectionConfiguration();
            RoyalApps.Community.Rdp.WinForms.Configuration.SecurityConfiguration securityConfiguration2 = new RoyalApps.Community.Rdp.WinForms.Configuration.SecurityConfiguration();
            axMsRdpClient91 = new RoyalApps.Community.Rdp.WinForms.Controls.RdpControl();
            SuspendLayout();
            // 
            // axMsRdpClient91
            // 
            axMsRdpClient91.Location = new Point(1, 2);
            axMsRdpClient91.Name = "axMsRdpClient91";
            rdpClientConfiguration2.ClientVersion = 0;
            connectionConfiguration2.Compression = false;
            connectionConfiguration2.ConnectionKeepAliveInterval = null;
            connectionConfiguration2.DisableUdpTransport = false;
            connectionConfiguration2.EnableAutoReconnect = false;
            connectionConfiguration2.EnableRdsAadAuth = false;
            connectionConfiguration2.KeepAlive = false;
            connectionConfiguration2.KeepAliveInterval = 60;
            connectionConfiguration2.KeepAliveMethod = RoyalApps.Community.Rdp.WinForms.Configuration.KeepAliveMethod.MouseMove;
            connectionConfiguration2.LoadBalanceInfo = null;
            connectionConfiguration2.MaxReconnectAttempts = 0;
            connectionConfiguration2.UseRedirectionServerName = false;
            rdpClientConfiguration2.Connection = connectionConfiguration2;
            credentialConfiguration2.Domain = null;
            credentialConfiguration2.NetworkLevelAuthentication = false;
            credentialConfiguration2.Password = null;
            credentialConfiguration2.PasswordContainsSmartCardPin = false;
            credentialConfiguration2.Username = null;
            rdpClientConfiguration2.Credentials = credentialConfiguration2;
            displayConfiguration2.AutoScaling = true;
            displayConfiguration2.ColorDepth = RoyalApps.Community.Rdp.WinForms.Configuration.ColorDepth.ColorDepth32Bpp;
            displayConfiguration2.ContainerHandledFullScreen = true;
            displayConfiguration2.DesktopHeight = 0;
            displayConfiguration2.DesktopWidth = 0;
            displayConfiguration2.DisplayConnectionBar = true;
            displayConfiguration2.FullScreen = false;
            displayConfiguration2.FullScreenTitle = null;
            displayConfiguration2.InitialZoomLevel = 100;
            displayConfiguration2.PinConnectionBar = false;
            displayConfiguration2.ResizeBehavior = RoyalApps.Community.Rdp.WinForms.Configuration.ResizeBehavior.SmartReconnect;
            displayConfiguration2.UseLocalScaling = false;
            displayConfiguration2.UseMultimon = false;
            rdpClientConfiguration2.Display = displayConfiguration2;
            gatewayConfiguration2.GatewayCredSharing = false;
            gatewayConfiguration2.GatewayCredsSource = RoyalApps.Community.Rdp.WinForms.Configuration.GatewayCredentialSource.UsernameAndPassword;
            gatewayConfiguration2.GatewayDomain = null;
            gatewayConfiguration2.GatewayHostname = null;
            gatewayConfiguration2.GatewayPassword = null;
            gatewayConfiguration2.GatewayProfileUsageMethod = RoyalApps.Community.Rdp.WinForms.Configuration.GatewayProfileUsageMethod.Default;
            gatewayConfiguration2.GatewayUsageMethod = RoyalApps.Community.Rdp.WinForms.Configuration.GatewayUsageMethod.Never;
            gatewayConfiguration2.GatewayUsername = null;
            gatewayConfiguration2.GatewayUserSelectedCredsSource = RoyalApps.Community.Rdp.WinForms.Configuration.GatewayCredentialSource.UsernameAndPassword;
            rdpClientConfiguration2.Gateway = gatewayConfiguration2;
            hypervConfiguration2.EnhancedSessionMode = false;
            hypervConfiguration2.HyperVPort = 2179;
            hypervConfiguration2.Instance = null;
            rdpClientConfiguration2.HyperV = hypervConfiguration2;
            inputConfiguration2.AcceleratorPassthrough = false;
            inputConfiguration2.AllowBackgroundInput = false;
            inputConfiguration2.DisableClickDetection = false;
            inputConfiguration2.EnableWindowsKey = false;
            inputConfiguration2.GrabFocusOnConnect = false;
            inputConfiguration2.KeyboardHookMode = false;
            inputConfiguration2.KeyBoardLayoutStr = null;
            inputConfiguration2.RelativeMouseMode = true;
            rdpClientConfiguration2.Input = inputConfiguration2;
            rdpClientConfiguration2.LogEnabled = false;
            rdpClientConfiguration2.LogFilePath = "C:\\Users\\ALX\\AppData\\Local\\Temp\\MsRdpEx.log";
            rdpClientConfiguration2.LogLevel = "TRACE";
            rdpClientConfiguration2.MsRdcPath = null;
            performanceConfiguration2.BandwidthDetection = false;
            performanceConfiguration2.BitmapCaching = false;
            performanceConfiguration2.ClientProtocolSpec = RoyalApps.Community.Rdp.WinForms.Configuration.ClientProtocolSpec.FullMode;
            performanceConfiguration2.DisableCursorSettings = false;
            performanceConfiguration2.DisableCursorShadow = false;
            performanceConfiguration2.DisableFullWindowDrag = false;
            performanceConfiguration2.DisableMenuAnimations = false;
            performanceConfiguration2.DisableTheming = false;
            performanceConfiguration2.DisableWallpaper = false;
            performanceConfiguration2.EnableDesktopComposition = false;
            performanceConfiguration2.EnableEnhancedGraphics = false;
            performanceConfiguration2.EnableFontSmoothing = false;
            performanceConfiguration2.EnableHardwareMode = false;
            performanceConfiguration2.NetworkConnectionType = RoyalApps.Community.Rdp.WinForms.Configuration.NetworkConnectionType.BroadbandHigh;
            performanceConfiguration2.RedirectDirectX = false;
            rdpClientConfiguration2.Performance = performanceConfiguration2;
            rdpClientConfiguration2.PluginDlls = null;
            rdpClientConfiguration2.Port = 3389;
            programConfiguration2.MaximizeShell = true;
            programConfiguration2.StartProgram = null;
            programConfiguration2.WorkDir = null;
            rdpClientConfiguration2.Program = programConfiguration2;
            redirectionConfiguration2.AudioCaptureRedirectionMode = false;
            redirectionConfiguration2.AudioQualityMode = RoyalApps.Community.Rdp.WinForms.Configuration.AudioQualityMode.Dynamic;
            redirectionConfiguration2.AudioRedirectionMode = RoyalApps.Community.Rdp.WinForms.Configuration.AudioRedirectionMode.RedirectToClient;
            redirectionConfiguration2.RedirectCameras = false;
            redirectionConfiguration2.RedirectClipboard = false;
            redirectionConfiguration2.RedirectDevices = false;
            redirectionConfiguration2.RedirectDriveLetters = null;
            redirectionConfiguration2.RedirectDrives = false;
            redirectionConfiguration2.RedirectLocation = false;
            redirectionConfiguration2.RedirectPointOfServiceDevices = false;
            redirectionConfiguration2.RedirectPorts = false;
            redirectionConfiguration2.RedirectPrinters = false;
            redirectionConfiguration2.RedirectSmartCards = false;
            redirectionConfiguration2.RedirectVideoRendering = false;
            rdpClientConfiguration2.Redirection = redirectionConfiguration2;
            securityConfiguration2.AuthenticationLevel = RoyalApps.Community.Rdp.WinForms.Configuration.AuthenticationLevel.NoAuthenticationOfServer;
            securityConfiguration2.ConnectToAdministerServer = false;
            securityConfiguration2.PublicMode = false;
            securityConfiguration2.RemoteCredentialGuard = false;
            securityConfiguration2.RestrictedAdminMode = false;
            rdpClientConfiguration2.Security = securityConfiguration2;
            rdpClientConfiguration2.Server = null;
            rdpClientConfiguration2.UseMsRdc = false;
            axMsRdpClient91.RdpConfiguration = rdpClientConfiguration2;
            axMsRdpClient91.Size = new Size(787, 446);
            axMsRdpClient91.TabIndex = 0;
            // 
            // RDPP
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(axMsRdpClient91);
            Name = "RDPP";
            Text = "RDP";
            ResumeLayout(false);
        }

        #endregion

        private RoyalApps.Community.Rdp.WinForms.Controls.RdpControl axMsRdpClient91;
    }
}