namespace SimpleTranslate
{
    partial class Main
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            layoutMain = new DevExpress.Utils.Layout.TablePanel();
            grpStats = new DevExpress.XtraEditors.GroupControl();
            lblStats = new DevExpress.XtraEditors.LabelControl();
            grpQuote = new DevExpress.XtraEditors.GroupControl();
            lblQuote = new DevExpress.XtraEditors.LabelControl();
            pnlActions = new DevExpress.Utils.Layout.StackPanel();
            btnTranslate = new DevExpress.XtraEditors.SimpleButton();
            btnSwap = new DevExpress.XtraEditors.SimpleButton();
            btnClear = new DevExpress.XtraEditors.SimpleButton();
            grpTarget = new DevExpress.XtraEditors.GroupControl();
            layoutTarget = new DevExpress.Utils.Layout.TablePanel();
            pnlTargetTools = new DevExpress.Utils.Layout.StackPanel();
            btnCopy = new DevExpress.XtraEditors.SimpleButton();
            btnSpeak = new DevExpress.XtraEditors.SimpleButton();
            picImage = new DevExpress.XtraEditors.PictureEdit();
            memoOutput = new DevExpress.XtraEditors.MemoEdit();
            cmbTargetLanguage = new DevExpress.XtraEditors.ComboBoxEdit();
            grpSource = new DevExpress.XtraEditors.GroupControl();
            memoInput = new DevExpress.XtraEditors.MemoEdit();
            cmbSourceLanguage = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)layoutMain).BeginInit();
            layoutMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grpStats).BeginInit();
            grpStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grpQuote).BeginInit();
            grpQuote.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlActions).BeginInit();
            pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grpTarget).BeginInit();
            grpTarget.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutTarget).BeginInit();
            layoutTarget.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlTargetTools).BeginInit();
            pnlTargetTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picImage.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)memoOutput.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbTargetLanguage.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grpSource).BeginInit();
            grpSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)memoInput.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbSourceLanguage.Properties).BeginInit();
            SuspendLayout();
            // 
            // layoutMain
            // 
            layoutMain.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] { new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F) });
            layoutMain.Controls.Add(grpStats);
            layoutMain.Controls.Add(grpQuote);
            layoutMain.Controls.Add(pnlActions);
            layoutMain.Controls.Add(grpTarget);
            layoutMain.Controls.Add(grpSource);
            layoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutMain.Location = new System.Drawing.Point(0, 0);
            layoutMain.Margin = new System.Windows.Forms.Padding(6);
            layoutMain.Name = "layoutMain";
            layoutMain.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] { new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 70F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 150F) });
            layoutMain.Size = new System.Drawing.Size(1833, 1061);
            layoutMain.TabIndex = 0;
            layoutMain.UseSkinIndents = true;
            // 
            // grpStats
            // 
            layoutMain.SetColumn(grpStats, 1);
            grpStats.Controls.Add(lblStats);
            grpStats.Dock = System.Windows.Forms.DockStyle.Fill;
            grpStats.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            grpStats.Location = new System.Drawing.Point(927, 897);
            grpStats.Margin = new System.Windows.Forms.Padding(10, 0, 10, 10);
            grpStats.Name = "grpStats";
            layoutMain.SetRow(grpStats, 2);
            grpStats.Size = new System.Drawing.Size(883, 140);
            grpStats.TabIndex = 4;
            grpStats.Text = "Statistics";
            // 
            // lblStats
            // 
            lblStats.Appearance.Options.UseTextOptions = true;
            lblStats.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblStats.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            lblStats.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblStats.Dock = System.Windows.Forms.DockStyle.Fill;
            lblStats.Location = new System.Drawing.Point(2, 30);
            lblStats.Margin = new System.Windows.Forms.Padding(6);
            lblStats.Name = "lblStats";
            lblStats.Size = new System.Drawing.Size(879, 108);
            lblStats.TabIndex = 0;
            lblStats.Text = "No translations yet.";
            // 
            // grpQuote
            // 
            layoutMain.SetColumn(grpQuote, 0);
            grpQuote.Controls.Add(lblQuote);
            grpQuote.Dock = System.Windows.Forms.DockStyle.Fill;
            grpQuote.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            grpQuote.Location = new System.Drawing.Point(24, 897);
            grpQuote.Margin = new System.Windows.Forms.Padding(10, 0, 10, 10);
            grpQuote.Name = "grpQuote";
            layoutMain.SetRow(grpQuote, 2);
            grpQuote.Size = new System.Drawing.Size(883, 140);
            grpQuote.TabIndex = 3;
            grpQuote.Text = "Quote of the Day";
            // 
            // lblQuote
            // 
            lblQuote.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            lblQuote.Appearance.Options.UseFont = true;
            lblQuote.Appearance.Options.UseTextOptions = true;
            lblQuote.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblQuote.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            lblQuote.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            lblQuote.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblQuote.Dock = System.Windows.Forms.DockStyle.Fill;
            lblQuote.Location = new System.Drawing.Point(2, 30);
            lblQuote.Margin = new System.Windows.Forms.Padding(6);
            lblQuote.Name = "lblQuote";
            lblQuote.Padding = new System.Windows.Forms.Padding(18, 19, 18, 19);
            lblQuote.Size = new System.Drawing.Size(879, 108);
            lblQuote.TabIndex = 0;
            lblQuote.Text = "One language sets you in a corridor for life.";
            // 
            // pnlActions
            // 
            layoutMain.SetColumn(pnlActions, 0);
            layoutMain.SetColumnSpan(pnlActions, 2);
            pnlActions.Controls.Add(btnTranslate);
            pnlActions.Controls.Add(btnSwap);
            pnlActions.Controls.Add(btnClear);
            pnlActions.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlActions.Location = new System.Drawing.Point(20, 833);
            pnlActions.Margin = new System.Windows.Forms.Padding(6);
            pnlActions.Name = "pnlActions";
            layoutMain.SetRow(pnlActions, 1);
            pnlActions.Size = new System.Drawing.Size(1794, 58);
            pnlActions.TabIndex = 2;
            // 
            // btnTranslate
            // 
            btnTranslate.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnTranslate.Appearance.Options.UseFont = true;
            btnTranslate.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnTranslate.Location = new System.Drawing.Point(6, -14);
            btnTranslate.Margin = new System.Windows.Forms.Padding(6);
            btnTranslate.Name = "btnTranslate";
            btnTranslate.Size = new System.Drawing.Size(293, 87);
            btnTranslate.TabIndex = 0;
            btnTranslate.Text = "TRANSLATE";
            // 
            // btnSwap
            // 
            btnSwap.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            btnSwap.Appearance.Options.UseFont = true;
            btnSwap.Location = new System.Drawing.Point(311, -14);
            btnSwap.Margin = new System.Windows.Forms.Padding(6);
            btnSwap.Name = "btnSwap";
            btnSwap.Size = new System.Drawing.Size(110, 87);
            btnSwap.TabIndex = 1;
            btnSwap.Text = "<>";
            btnSwap.ToolTip = "Swap Languages";
            // 
            // btnClear
            // 
            btnClear.Appearance.ForeColor = System.Drawing.Color.Gray;
            btnClear.Appearance.Options.UseForeColor = true;
            btnClear.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnClear.Location = new System.Drawing.Point(433, -14);
            btnClear.Margin = new System.Windows.Forms.Padding(6);
            btnClear.Name = "btnClear";
            btnClear.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            btnClear.Size = new System.Drawing.Size(183, 87);
            btnClear.TabIndex = 2;
            btnClear.Text = "Clear";
            // 
            // grpTarget
            // 
            layoutMain.SetColumn(grpTarget, 1);
            grpTarget.Controls.Add(layoutTarget);
            grpTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            grpTarget.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            grpTarget.Location = new System.Drawing.Point(927, 23);
            grpTarget.Margin = new System.Windows.Forms.Padding(10);
            grpTarget.Name = "grpTarget";
            layoutMain.SetRow(grpTarget, 0);
            grpTarget.Size = new System.Drawing.Size(883, 794);
            grpTarget.TabIndex = 1;
            grpTarget.Text = "Translation Result";
            // 
            // layoutTarget
            // 
            layoutTarget.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] { new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F) });
            layoutTarget.Controls.Add(pnlTargetTools);
            layoutTarget.Controls.Add(picImage);
            layoutTarget.Controls.Add(memoOutput);
            layoutTarget.Controls.Add(cmbTargetLanguage);
            layoutTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutTarget.Location = new System.Drawing.Point(2, 30);
            layoutTarget.Margin = new System.Windows.Forms.Padding(6);
            layoutTarget.Name = "layoutTarget";
            layoutTarget.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] { new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 30F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 40F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F) });
            layoutTarget.Size = new System.Drawing.Size(879, 762);
            layoutTarget.TabIndex = 0;
            // 
            // pnlTargetTools
            // 
            layoutTarget.SetColumn(pnlTargetTools, 0);
            pnlTargetTools.Controls.Add(btnCopy);
            pnlTargetTools.Controls.Add(btnSpeak);
            pnlTargetTools.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlTargetTools.LayoutDirection = DevExpress.Utils.Layout.StackPanelLayoutDirection.RightToLeft;
            pnlTargetTools.Location = new System.Drawing.Point(6, 375);
            pnlTargetTools.Margin = new System.Windows.Forms.Padding(6);
            pnlTargetTools.Name = "pnlTargetTools";
            layoutTarget.SetRow(pnlTargetTools, 2);
            pnlTargetTools.Size = new System.Drawing.Size(867, 65);
            pnlTargetTools.TabIndex = 3;
            // 
            // btnCopy
            // 
            btnCopy.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnCopy.Location = new System.Drawing.Point(714, 3);
            btnCopy.Margin = new System.Windows.Forms.Padding(6);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new System.Drawing.Size(147, 58);
            btnCopy.TabIndex = 0;
            btnCopy.Text = "Copy";
            btnCopy.ToolTip = "Copy to Clipboard";
            // 
            // btnSpeak
            // 
            btnSpeak.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnSpeak.Location = new System.Drawing.Point(555, 3);
            btnSpeak.Margin = new System.Windows.Forms.Padding(6);
            btnSpeak.Name = "btnSpeak";
            btnSpeak.Size = new System.Drawing.Size(147, 58);
            btnSpeak.TabIndex = 1;
            btnSpeak.Text = "Speak";
            btnSpeak.ToolTip = "Read Aloud";
            // 
            // picImage
            // 
            layoutTarget.SetColumn(picImage, 0);
            picImage.Dock = System.Windows.Forms.DockStyle.Fill;
            picImage.Location = new System.Drawing.Point(6, 452);
            picImage.Margin = new System.Windows.Forms.Padding(6);
            picImage.Name = "picImage";
            picImage.Properties.NullText = "Related image will appear here";
            picImage.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            picImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            layoutTarget.SetRow(picImage, 3);
            picImage.Size = new System.Drawing.Size(867, 304);
            picImage.TabIndex = 2;
            // 
            // memoOutput
            // 
            layoutTarget.SetColumn(memoOutput, 0);
            memoOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            memoOutput.Location = new System.Drawing.Point(6, 58);
            memoOutput.Margin = new System.Windows.Forms.Padding(6);
            memoOutput.Name = "memoOutput";
            memoOutput.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            memoOutput.Properties.ReadOnly = true;
            memoOutput.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            layoutTarget.SetRow(memoOutput, 1);
            memoOutput.Size = new System.Drawing.Size(867, 305);
            memoOutput.TabIndex = 1;
            // 
            // cmbTargetLanguage
            // 
            layoutTarget.SetColumn(cmbTargetLanguage, 0);
            cmbTargetLanguage.Dock = System.Windows.Forms.DockStyle.Fill;
            cmbTargetLanguage.Location = new System.Drawing.Point(6, 6);
            cmbTargetLanguage.Margin = new System.Windows.Forms.Padding(6);
            cmbTargetLanguage.Name = "cmbTargetLanguage";
            cmbTargetLanguage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbTargetLanguage.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            layoutTarget.SetRow(cmbTargetLanguage, 0);
            cmbTargetLanguage.Size = new System.Drawing.Size(867, 40);
            cmbTargetLanguage.TabIndex = 0;
            // 
            // grpSource
            // 
            layoutMain.SetColumn(grpSource, 0);
            grpSource.Controls.Add(memoInput);
            grpSource.Controls.Add(cmbSourceLanguage);
            grpSource.Dock = System.Windows.Forms.DockStyle.Fill;
            grpSource.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            grpSource.Location = new System.Drawing.Point(24, 23);
            grpSource.Margin = new System.Windows.Forms.Padding(10);
            grpSource.Name = "grpSource";
            layoutMain.SetRow(grpSource, 0);
            grpSource.Size = new System.Drawing.Size(883, 794);
            grpSource.TabIndex = 0;
            grpSource.Text = "Source Text";
            // 
            // memoInput
            // 
            memoInput.Dock = System.Windows.Forms.DockStyle.Fill;
            memoInput.Location = new System.Drawing.Point(2, 70);
            memoInput.Margin = new System.Windows.Forms.Padding(6);
            memoInput.Name = "memoInput";
            memoInput.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            memoInput.Properties.NullValuePrompt = "Enter text to translate...";
            memoInput.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            memoInput.Size = new System.Drawing.Size(879, 722);
            memoInput.TabIndex = 1;
            // 
            // cmbSourceLanguage
            // 
            cmbSourceLanguage.Dock = System.Windows.Forms.DockStyle.Top;
            cmbSourceLanguage.Location = new System.Drawing.Point(2, 30);
            cmbSourceLanguage.Margin = new System.Windows.Forms.Padding(6);
            cmbSourceLanguage.Name = "cmbSourceLanguage";
            cmbSourceLanguage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbSourceLanguage.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cmbSourceLanguage.Size = new System.Drawing.Size(879, 40);
            cmbSourceLanguage.TabIndex = 0;
            // 
            // Main
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1833, 1061);
            Controls.Add(layoutMain);
            Font = new System.Drawing.Font("Segoe UI", 14.25F);
            Margin = new System.Windows.Forms.Padding(6);
            Name = "Main";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SimpleTranslate";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Load += Main_Load;
            ((System.ComponentModel.ISupportInitialize)layoutMain).EndInit();
            layoutMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grpStats).EndInit();
            grpStats.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grpQuote).EndInit();
            grpQuote.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlActions).EndInit();
            pnlActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grpTarget).EndInit();
            grpTarget.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)layoutTarget).EndInit();
            layoutTarget.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlTargetTools).EndInit();
            pnlTargetTools.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picImage.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)memoOutput.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbTargetLanguage.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)grpSource).EndInit();
            grpSource.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)memoInput.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbSourceLanguage.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        // Layout Controls
        private DevExpress.Utils.Layout.TablePanel layoutMain;
        private DevExpress.Utils.Layout.TablePanel layoutTarget;
        private DevExpress.Utils.Layout.StackPanel pnlActions;
        private DevExpress.Utils.Layout.StackPanel pnlTargetTools;

        // Group Controls
        private DevExpress.XtraEditors.GroupControl grpSource;
        private DevExpress.XtraEditors.GroupControl grpTarget;
        private DevExpress.XtraEditors.GroupControl grpQuote;
        private DevExpress.XtraEditors.GroupControl grpStats;

        // Input/Output Controls
        private DevExpress.XtraEditors.ComboBoxEdit cmbSourceLanguage;
        private DevExpress.XtraEditors.ComboBoxEdit cmbTargetLanguage;
        private DevExpress.XtraEditors.MemoEdit memoInput;
        private DevExpress.XtraEditors.MemoEdit memoOutput;
        private DevExpress.XtraEditors.PictureEdit picImage;

        // Labels
        private DevExpress.XtraEditors.LabelControl lblQuote;
        private DevExpress.XtraEditors.LabelControl lblStats;

        // Buttons
        private DevExpress.XtraEditors.SimpleButton btnTranslate;
        private DevExpress.XtraEditors.SimpleButton btnSwap;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnCopy;
        private DevExpress.XtraEditors.SimpleButton btnSpeak;
    }
}