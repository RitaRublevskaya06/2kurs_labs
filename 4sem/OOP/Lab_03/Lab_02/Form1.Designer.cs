namespace Lab_02
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.pageAdd = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Total = new System.Windows.Forms.NumericUpDown();
            this.Transaction = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.OperationType = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.SaveButton = new System.Windows.Forms.Button();
            this.balanceText = new System.Windows.Forms.Label();
            this.RestoreButton = new System.Windows.Forms.Button();
            this.numberOfAccount = new System.Windows.Forms.MaskedTextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.passportField = new System.Windows.Forms.MaskedTextBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.FIOField = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBoxInternet = new System.Windows.Forms.CheckBox();
            this.trackBarBalanse = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.SMSPanel = new System.Windows.Forms.Panel();
            this.radioButtonNo = new System.Windows.Forms.RadioButton();
            this.radioButtonYes = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AccountTypeField = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lableInfoOwner = new System.Windows.Forms.Label();
            this.labelInfoAccount = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pageDataBase = new System.Windows.Forms.TabPage();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.FIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Passport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Birth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpenDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SMS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Banking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pageMemory = new System.Windows.Forms.TabPage();
            this.HistoryGridView = new System.Windows.Forms.DataGridView();
            this.DateGridView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalGridView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperationTypeGridView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorProviderFIO = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderNumberAcc = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderPassport = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderTypeOfAcc = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderSMS = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderTotal = new System.Windows.Forms.ErrorProvider(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.dateLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.actionUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusObjects = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ОпрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поискToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl.SuspendLayout();
            this.pageAdd.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Total)).BeginInit();
            this.panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBalanse)).BeginInit();
            this.SMSPanel.SuspendLayout();
            this.pageDataBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.pageMemory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HistoryGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderFIO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderNumberAcc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPassport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderTypeOfAcc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderSMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderTotal)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.pageAdd);
            this.tabControl.Controls.Add(this.pageDataBase);
            this.tabControl.Controls.Add(this.pageMemory);
            this.tabControl.Location = new System.Drawing.Point(-3, 31);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1259, 544);
            this.tabControl.TabIndex = 0;
            this.tabControl.Enter += new System.EventHandler(this.tabControl_Enter);
            // 
            // pageAdd
            // 
            this.pageAdd.BackColor = System.Drawing.Color.SteelBlue;
            this.pageAdd.Controls.Add(this.panel1);
            this.pageAdd.Controls.Add(this.panelInfo);
            this.pageAdd.Controls.Add(this.splitter1);
            this.pageAdd.Location = new System.Drawing.Point(4, 25);
            this.pageAdd.Name = "pageAdd";
            this.pageAdd.Padding = new System.Windows.Forms.Padding(3);
            this.pageAdd.Size = new System.Drawing.Size(1251, 515);
            this.pageAdd.TabIndex = 0;
            this.pageAdd.Text = "Добавление";
            this.pageAdd.TextChanged += new System.EventHandler(this.pageAdd_TextChanged_1);
            this.pageAdd.Enter += new System.EventHandler(this.pageAdd_Enter);
            this.pageAdd.MouseHover += new System.EventHandler(this.pageAdd_MouseHover);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.Total);
            this.panel1.Controls.Add(this.Transaction);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.OperationType);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(824, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(387, 242);
            this.panel1.TabIndex = 78;
            // 
            // Total
            // 
            this.Total.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Italic);
            this.Total.Location = new System.Drawing.Point(48, 131);
            this.Total.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(284, 25);
            this.Total.TabIndex = 79;
            this.Total.Validating += new System.ComponentModel.CancelEventHandler(this.Total_Validating_1);
            this.Total.Validated += new System.EventHandler(this.Total_Validated_1);
            // 
            // Transaction
            // 
            this.Transaction.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Transaction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Transaction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Transaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Transaction.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Italic);
            this.Transaction.Location = new System.Drawing.Point(48, 186);
            this.Transaction.Margin = new System.Windows.Forms.Padding(4);
            this.Transaction.Name = "Transaction";
            this.Transaction.Size = new System.Drawing.Size(286, 28);
            this.Transaction.TabIndex = 76;
            this.Transaction.Text = "Выполнить";
            this.Transaction.UseVisualStyleBackColor = false;
            this.Transaction.Click += new System.EventHandler(this.Transaction_Click);
            this.Transaction.MouseHover += new System.EventHandler(this.Transaction_MouseHover);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Italic);
            this.label12.Location = new System.Drawing.Point(45, 104);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(153, 18);
            this.label12.TabIndex = 74;
            this.label12.Text = "Сумма транзакции";
            // 
            // OperationType
            // 
            this.OperationType.BackColor = System.Drawing.SystemColors.Menu;
            this.OperationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OperationType.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Italic);
            this.OperationType.FormattingEnabled = true;
            this.OperationType.Items.AddRange(new object[] {
            "Перевод",
            "Снятие",
            "Пополнение",
            "Платеж"});
            this.OperationType.Location = new System.Drawing.Point(48, 72);
            this.OperationType.Margin = new System.Windows.Forms.Padding(4);
            this.OperationType.Name = "OperationType";
            this.OperationType.Size = new System.Drawing.Size(284, 26);
            this.OperationType.TabIndex = 73;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Italic);
            this.label13.Location = new System.Drawing.Point(45, 52);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(128, 18);
            this.label13.TabIndex = 72;
            this.label13.Text = "Тип транзакции";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Bookman Old Style", 13.8F, System.Drawing.FontStyle.Italic);
            this.label11.Location = new System.Drawing.Point(43, 14);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(302, 26);
            this.label11.TabIndex = 71;
            this.label11.Text = "Выполнить транзакцию";
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.Color.LightBlue;
            this.panelInfo.Controls.Add(this.SaveButton);
            this.panelInfo.Controls.Add(this.balanceText);
            this.panelInfo.Controls.Add(this.RestoreButton);
            this.panelInfo.Controls.Add(this.numberOfAccount);
            this.panelInfo.Controls.Add(this.AddButton);
            this.panelInfo.Controls.Add(this.passportField);
            this.panelInfo.Controls.Add(this.dateTimePicker);
            this.panelInfo.Controls.Add(this.label6);
            this.panelInfo.Controls.Add(this.label9);
            this.panelInfo.Controls.Add(this.FIOField);
            this.panelInfo.Controls.Add(this.label8);
            this.panelInfo.Controls.Add(this.checkBoxInternet);
            this.panelInfo.Controls.Add(this.trackBarBalanse);
            this.panelInfo.Controls.Add(this.label5);
            this.panelInfo.Controls.Add(this.SMSPanel);
            this.panelInfo.Controls.Add(this.label1);
            this.panelInfo.Controls.Add(this.label3);
            this.panelInfo.Controls.Add(this.AccountTypeField);
            this.panelInfo.Controls.Add(this.label2);
            this.panelInfo.Controls.Add(this.lableInfoOwner);
            this.panelInfo.Controls.Add(this.labelInfoAccount);
            this.panelInfo.Location = new System.Drawing.Point(84, 19);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(697, 451);
            this.panelInfo.TabIndex = 77;
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.SaveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SaveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Italic);
            this.SaveButton.Location = new System.Drawing.Point(459, 391);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(4);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(195, 28);
            this.SaveButton.TabIndex = 65;
            this.SaveButton.Text = "Сохранить в xml";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            this.SaveButton.MouseHover += new System.EventHandler(this.SaveButton_MouseHover);
            // 
            // balanceText
            // 
            this.balanceText.AutoSize = true;
            this.balanceText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.balanceText.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Italic);
            this.balanceText.Location = new System.Drawing.Point(93, 159);
            this.balanceText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.balanceText.Name = "balanceText";
            this.balanceText.Size = new System.Drawing.Size(13, 18);
            this.balanceText.TabIndex = 69;
            this.balanceText.Text = ":";
            // 
            // RestoreButton
            // 
            this.RestoreButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.RestoreButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RestoreButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RestoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RestoreButton.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Italic);
            this.RestoreButton.Location = new System.Drawing.Point(247, 391);
            this.RestoreButton.Margin = new System.Windows.Forms.Padding(4);
            this.RestoreButton.Name = "RestoreButton";
            this.RestoreButton.Size = new System.Drawing.Size(195, 28);
            this.RestoreButton.TabIndex = 64;
            this.RestoreButton.Text = "Восстановить из xml";
            this.RestoreButton.UseVisualStyleBackColor = false;
            this.RestoreButton.Click += new System.EventHandler(this.RestoreButton_Click);
            this.RestoreButton.MouseEnter += new System.EventHandler(this.RestoreButton_MouseEnter);
            // 
            // numberOfAccount
            // 
            this.numberOfAccount.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Italic);
            this.numberOfAccount.Location = new System.Drawing.Point(35, 73);
            this.numberOfAccount.Mask = "000000";
            this.numberOfAccount.Name = "numberOfAccount";
            this.numberOfAccount.Size = new System.Drawing.Size(261, 25);
            this.numberOfAccount.TabIndex = 68;
            this.numberOfAccount.ValidatingType = typeof(int);
            this.numberOfAccount.TextChanged += new System.EventHandler(this.pageAdd_TextChanged_1);
            this.numberOfAccount.Validating += new System.ComponentModel.CancelEventHandler(this.numberOfAccount_Validating);
            this.numberOfAccount.Validated += new System.EventHandler(this.numberOfAccount_Validated);
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.AddButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AddButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Italic);
            this.AddButton.Location = new System.Drawing.Point(31, 391);
            this.AddButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(195, 28);
            this.AddButton.TabIndex = 63;
            this.AddButton.Text = "Добавить в таблицу";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            this.AddButton.MouseHover += new System.EventHandler(this.AddButton_MouseHover);
            // 
            // passportField
            // 
            this.passportField.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Italic);
            this.passportField.Location = new System.Drawing.Point(393, 183);
            this.passportField.Mask = ">LL0000000";
            this.passportField.Name = "passportField";
            this.passportField.Size = new System.Drawing.Size(261, 25);
            this.passportField.TabIndex = 67;
            this.passportField.ValidatingType = typeof(int);
            this.passportField.TextChanged += new System.EventHandler(this.passportField_TextChanged);
            this.passportField.Validating += new System.ComponentModel.CancelEventHandler(this.passportField_Validating);
            this.passportField.Validated += new System.EventHandler(this.passportField_Validated);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Italic);
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.Location = new System.Drawing.Point(393, 127);
            this.dateTimePicker.MaxDate = new System.DateTime(2007, 2, 28, 0, 0, 0, 0);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(262, 25);
            this.dateTimePicker.TabIndex = 67;
            this.dateTimePicker.Value = new System.DateTime(2007, 2, 28, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Italic);
            this.label6.Location = new System.Drawing.Point(390, 159);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(191, 18);
            this.label6.TabIndex = 61;
            this.label6.Text = "Серия и номер паспорта";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Italic);
            this.label9.Location = new System.Drawing.Point(391, 104);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 18);
            this.label9.TabIndex = 59;
            this.label9.Text = "Дата рождения";
            // 
            // FIOField
            // 
            this.FIOField.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Italic);
            this.FIOField.Location = new System.Drawing.Point(394, 73);
            this.FIOField.Margin = new System.Windows.Forms.Padding(4);
            this.FIOField.Name = "FIOField";
            this.FIOField.Size = new System.Drawing.Size(261, 25);
            this.FIOField.TabIndex = 58;
            this.FIOField.TextChanged += new System.EventHandler(this.FIOField_TextChanged);
            this.FIOField.Validating += new System.ComponentModel.CancelEventHandler(this.FIOField_Validating);
            this.FIOField.Validated += new System.EventHandler(this.FIOField_Validated);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Italic);
            this.label8.Location = new System.Drawing.Point(390, 52);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 18);
            this.label8.TabIndex = 57;
            this.label8.Text = "ФИО";
            // 
            // checkBoxInternet
            // 
            this.checkBoxInternet.AutoSize = true;
            this.checkBoxInternet.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxInternet.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Italic);
            this.checkBoxInternet.Location = new System.Drawing.Point(34, 326);
            this.checkBoxInternet.Name = "checkBoxInternet";
            this.checkBoxInternet.Size = new System.Drawing.Size(276, 22);
            this.checkBoxInternet.TabIndex = 56;
            this.checkBoxInternet.Text = "Подключить интернет-банкинг?";
            this.checkBoxInternet.UseVisualStyleBackColor = true;
            // 
            // trackBarBalanse
            // 
            this.trackBarBalanse.BackColor = System.Drawing.Color.LightBlue;
            this.trackBarBalanse.Location = new System.Drawing.Point(34, 186);
            this.trackBarBalanse.Maximum = 1000;
            this.trackBarBalanse.Name = "trackBarBalanse";
            this.trackBarBalanse.Size = new System.Drawing.Size(262, 56);
            this.trackBarBalanse.TabIndex = 55;
            this.trackBarBalanse.Scroll += new System.EventHandler(this.trackBarBalanse_Scroll);
            this.trackBarBalanse.ValueChanged += new System.EventHandler(this.trackBarBalanse_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Italic);
            this.label5.Location = new System.Drawing.Point(32, 52);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 18);
            this.label5.TabIndex = 52;
            this.label5.Text = "Номер счета";
            // 
            // SMSPanel
            // 
            this.SMSPanel.Controls.Add(this.radioButtonNo);
            this.SMSPanel.Controls.Add(this.radioButtonYes);
            this.SMSPanel.Location = new System.Drawing.Point(36, 266);
            this.SMSPanel.Margin = new System.Windows.Forms.Padding(4);
            this.SMSPanel.Name = "SMSPanel";
            this.SMSPanel.Size = new System.Drawing.Size(260, 31);
            this.SMSPanel.TabIndex = 51;
            // 
            // radioButtonNo
            // 
            this.radioButtonNo.AutoSize = true;
            this.radioButtonNo.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Italic);
            this.radioButtonNo.Location = new System.Drawing.Point(60, 4);
            this.radioButtonNo.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonNo.Name = "radioButtonNo";
            this.radioButtonNo.Size = new System.Drawing.Size(61, 22);
            this.radioButtonNo.TabIndex = 9;
            this.radioButtonNo.TabStop = true;
            this.radioButtonNo.Text = "Нет";
            this.radioButtonNo.UseVisualStyleBackColor = true;
            // 
            // radioButtonYes
            // 
            this.radioButtonYes.AutoSize = true;
            this.radioButtonYes.Checked = true;
            this.radioButtonYes.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Italic);
            this.radioButtonYes.Location = new System.Drawing.Point(4, 5);
            this.radioButtonYes.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonYes.Name = "radioButtonYes";
            this.radioButtonYes.Size = new System.Drawing.Size(48, 22);
            this.radioButtonYes.TabIndex = 8;
            this.radioButtonYes.TabStop = true;
            this.radioButtonYes.Text = "Да";
            this.radioButtonYes.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Italic);
            this.label1.Location = new System.Drawing.Point(32, 159);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.TabIndex = 48;
            this.label1.Text = "Баланс";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Italic);
            this.label3.Location = new System.Drawing.Point(32, 245);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(244, 18);
            this.label3.TabIndex = 46;
            this.label3.Text = "Подключить СМС-оповещения?";
            // 
            // AccountTypeField
            // 
            this.AccountTypeField.BackColor = System.Drawing.SystemColors.Menu;
            this.AccountTypeField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AccountTypeField.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Italic);
            this.AccountTypeField.FormattingEnabled = true;
            this.AccountTypeField.Items.AddRange(new object[] {
            "Текущий ",
            "Расчетный",
            "Кредитный",
            "Депозитный",
            "Бюджетный"});
            this.AccountTypeField.Location = new System.Drawing.Point(34, 125);
            this.AccountTypeField.Margin = new System.Windows.Forms.Padding(4);
            this.AccountTypeField.Name = "AccountTypeField";
            this.AccountTypeField.Size = new System.Drawing.Size(261, 26);
            this.AccountTypeField.TabIndex = 45;
            this.AccountTypeField.TextChanged += new System.EventHandler(this.AccountTypeField_TextChanged);
            this.AccountTypeField.Validating += new System.ComponentModel.CancelEventHandler(this.AccountTypeField_Validating);
            this.AccountTypeField.Validated += new System.EventHandler(this.AccountTypeField_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Italic);
            this.label2.Location = new System.Drawing.Point(30, 104);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 18);
            this.label2.TabIndex = 44;
            this.label2.Text = "Тип счета";
            // 
            // lableInfoOwner
            // 
            this.lableInfoOwner.AutoSize = true;
            this.lableInfoOwner.Font = new System.Drawing.Font("Bookman Old Style", 13.8F, System.Drawing.FontStyle.Italic);
            this.lableInfoOwner.Location = new System.Drawing.Point(389, 14);
            this.lableInfoOwner.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lableInfoOwner.Name = "lableInfoOwner";
            this.lableInfoOwner.Size = new System.Drawing.Size(270, 26);
            this.lableInfoOwner.TabIndex = 38;
            this.lableInfoOwner.Text = "Персональные данные";
            // 
            // labelInfoAccount
            // 
            this.labelInfoAccount.AutoSize = true;
            this.labelInfoAccount.Font = new System.Drawing.Font("Bookman Old Style", 13.8F, System.Drawing.FontStyle.Italic);
            this.labelInfoAccount.Location = new System.Drawing.Point(29, 14);
            this.labelInfoAccount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInfoAccount.Name = "labelInfoAccount";
            this.labelInfoAccount.Size = new System.Drawing.Size(258, 26);
            this.labelInfoAccount.TabIndex = 37;
            this.labelInfoAccount.Text = "Информация о счете";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(3, 3);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 509);
            this.splitter1.TabIndex = 54;
            this.splitter1.TabStop = false;
            // 
            // pageDataBase
            // 
            this.pageDataBase.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pageDataBase.Controls.Add(this.dataGridView);
            this.pageDataBase.Location = new System.Drawing.Point(4, 25);
            this.pageDataBase.Name = "pageDataBase";
            this.pageDataBase.Padding = new System.Windows.Forms.Padding(3);
            this.pageDataBase.Size = new System.Drawing.Size(1251, 515);
            this.pageDataBase.TabIndex = 1;
            this.pageDataBase.Text = "Таблица";
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FIO,
            this.Passport,
            this.Birth,
            this.AccountType,
            this.Balance,
            this.OpenDate,
            this.SMS,
            this.Banking});
            this.dataGridView.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.Location = new System.Drawing.Point(12, 17);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.Size = new System.Drawing.Size(1261, 456);
            this.dataGridView.TabIndex = 46;
            // 
            // FIO
            // 
            this.FIO.Frozen = true;
            this.FIO.HeaderText = "ФИО";
            this.FIO.MinimumWidth = 6;
            this.FIO.Name = "FIO";
            this.FIO.ReadOnly = true;
            this.FIO.Width = 170;
            // 
            // Passport
            // 
            this.Passport.Frozen = true;
            this.Passport.HeaderText = "Паспорт";
            this.Passport.MinimumWidth = 6;
            this.Passport.Name = "Passport";
            this.Passport.ReadOnly = true;
            this.Passport.Width = 105;
            // 
            // Birth
            // 
            this.Birth.Frozen = true;
            this.Birth.HeaderText = "Дата рождения";
            this.Birth.MinimumWidth = 6;
            this.Birth.Name = "Birth";
            this.Birth.ReadOnly = true;
            this.Birth.Width = 125;
            // 
            // AccountType
            // 
            this.AccountType.Frozen = true;
            this.AccountType.HeaderText = "Тип счета";
            this.AccountType.MinimumWidth = 6;
            this.AccountType.Name = "AccountType";
            this.AccountType.ReadOnly = true;
            this.AccountType.Width = 125;
            // 
            // Balance
            // 
            this.Balance.Frozen = true;
            this.Balance.HeaderText = "Баланс";
            this.Balance.MinimumWidth = 6;
            this.Balance.Name = "Balance";
            this.Balance.ReadOnly = true;
            this.Balance.Width = 125;
            // 
            // OpenDate
            // 
            this.OpenDate.Frozen = true;
            this.OpenDate.HeaderText = "Дата Открытия";
            this.OpenDate.MinimumWidth = 6;
            this.OpenDate.Name = "OpenDate";
            this.OpenDate.ReadOnly = true;
            this.OpenDate.Width = 125;
            // 
            // SMS
            // 
            this.SMS.Frozen = true;
            this.SMS.HeaderText = "СМС";
            this.SMS.MinimumWidth = 6;
            this.SMS.Name = "SMS";
            this.SMS.ReadOnly = true;
            this.SMS.Width = 70;
            // 
            // Banking
            // 
            this.Banking.Frozen = true;
            this.Banking.HeaderText = "Банкинг";
            this.Banking.MinimumWidth = 6;
            this.Banking.Name = "Banking";
            this.Banking.ReadOnly = true;
            this.Banking.Width = 70;
            // 
            // pageMemory
            // 
            this.pageMemory.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pageMemory.Controls.Add(this.HistoryGridView);
            this.pageMemory.Location = new System.Drawing.Point(4, 25);
            this.pageMemory.Name = "pageMemory";
            this.pageMemory.Size = new System.Drawing.Size(1251, 515);
            this.pageMemory.TabIndex = 2;
            this.pageMemory.Text = "История операций";
            // 
            // HistoryGridView
            // 
            this.HistoryGridView.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.HistoryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HistoryGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DateGridView,
            this.TotalGridView,
            this.OperationTypeGridView});
            this.HistoryGridView.EnableHeadersVisualStyles = false;
            this.HistoryGridView.Location = new System.Drawing.Point(62, 31);
            this.HistoryGridView.Margin = new System.Windows.Forms.Padding(4);
            this.HistoryGridView.Name = "HistoryGridView";
            this.HistoryGridView.RowHeadersWidth = 51;
            this.HistoryGridView.Size = new System.Drawing.Size(619, 439);
            this.HistoryGridView.TabIndex = 1;
            // 
            // DateGridView
            // 
            this.DateGridView.HeaderText = "Дата";
            this.DateGridView.MinimumWidth = 6;
            this.DateGridView.Name = "DateGridView";
            this.DateGridView.ReadOnly = true;
            this.DateGridView.Width = 150;
            // 
            // TotalGridView
            // 
            this.TotalGridView.HeaderText = "Сумма";
            this.TotalGridView.MinimumWidth = 6;
            this.TotalGridView.Name = "TotalGridView";
            this.TotalGridView.ReadOnly = true;
            this.TotalGridView.Width = 125;
            // 
            // OperationTypeGridView
            // 
            this.OperationTypeGridView.HeaderText = "Тип операции";
            this.OperationTypeGridView.MinimumWidth = 6;
            this.OperationTypeGridView.Name = "OperationTypeGridView";
            this.OperationTypeGridView.ReadOnly = true;
            this.OperationTypeGridView.Width = 300;
            // 
            // errorProviderFIO
            // 
            this.errorProviderFIO.ContainerControl = this;
            // 
            // errorProviderNumberAcc
            // 
            this.errorProviderNumberAcc.ContainerControl = this;
            // 
            // errorProviderPassport
            // 
            this.errorProviderPassport.ContainerControl = this;
            // 
            // errorProviderTypeOfAcc
            // 
            this.errorProviderTypeOfAcc.ContainerControl = this;
            // 
            // errorProviderSMS
            // 
            this.errorProviderSMS.ContainerControl = this;
            // 
            // errorProviderTotal
            // 
            this.errorProviderTotal.ContainerControl = this;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateLabel,
            this.toolStripStatusLabel1,
            this.actionUser,
            this.StatusObjects});
            this.statusStrip.Location = new System.Drawing.Point(0, 549);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(1268, 26);
            this.statusStrip.TabIndex = 56;
            this.statusStrip.Text = "statusStrip";
            // 
            // dateLabel
            // 
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(82, 20);
            this.dateLabel.Text = "StatusTime";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(70, 20);
            this.toolStripStatusLabel1.Text = "Aктивно:";
            // 
            // actionUser
            // 
            this.actionUser.Name = "actionUser";
            this.actionUser.Size = new System.Drawing.Size(107, 20);
            this.actionUser.Text = "toolStripStatus";
            // 
            // StatusObjects
            // 
            this.StatusObjects.Name = "StatusObjects";
            this.StatusObjects.Size = new System.Drawing.Size(159, 20);
            this.StatusObjects.Text = "Количество счетов:  0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ОпрограммеToolStripMenuItem,
            this.поискToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1268, 28);
            this.menuStrip1.TabIndex = 57;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MouseEnter += new System.EventHandler(this.menuStrip1_MouseEnter);
            // 
            // ОпрограммеToolStripMenuItem
            // 
            this.ОпрограммеToolStripMenuItem.Name = "ОпрограммеToolStripMenuItem";
            this.ОпрограммеToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.ОпрограммеToolStripMenuItem.Text = "О программе";
            this.ОпрограммеToolStripMenuItem.Click += new System.EventHandler(this.ОпрограммеToolStripMenuItem_Click);
            // 
            // поискToolStripMenuItem1
            // 
            this.поискToolStripMenuItem1.Name = "поискToolStripMenuItem1";
            this.поискToolStripMenuItem1.Size = new System.Drawing.Size(66, 24);
            this.поискToolStripMenuItem1.Text = "Поиск";
            this.поискToolStripMenuItem1.Click += new System.EventHandler(this.поискToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 575);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ChangeUICues += new System.Windows.Forms.UICuesEventHandler(this.Form1_ChangeUICues);
            this.tabControl.ResumeLayout(false);
            this.pageAdd.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Total)).EndInit();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBalanse)).EndInit();
            this.SMSPanel.ResumeLayout(false);
            this.SMSPanel.PerformLayout();
            this.pageDataBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.pageMemory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HistoryGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderFIO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderNumberAcc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPassport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderTypeOfAcc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderSMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderTotal)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage pageAdd;
        private System.Windows.Forms.TabPage pageDataBase;
        private System.Windows.Forms.TabPage pageMemory;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button RestoreButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox FIOField;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBoxInternet;
        private System.Windows.Forms.TrackBar trackBarBalanse;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel SMSPanel;
        private System.Windows.Forms.RadioButton radioButtonNo;
        private System.Windows.Forms.RadioButton radioButtonYes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox AccountTypeField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lableInfoOwner;
        private System.Windows.Forms.Label labelInfoAccount;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.MaskedTextBox passportField;
        private System.Windows.Forms.MaskedTextBox numberOfAccount;
        private System.Windows.Forms.ErrorProvider errorProviderFIO;
        private System.Windows.Forms.ErrorProvider errorProviderNumberAcc;
        private System.Windows.Forms.ErrorProvider errorProviderPassport;
        private System.Windows.Forms.ErrorProvider errorProviderTypeOfAcc;
        private System.Windows.Forms.ErrorProvider errorProviderSMS;
        private System.Windows.Forms.Button Transaction;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox OperationType;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView HistoryGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperationTypeGridView;
        private System.Windows.Forms.ErrorProvider errorProviderTotal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.NumericUpDown Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn FIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Passport;
        private System.Windows.Forms.DataGridViewTextBoxColumn Birth;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpenDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SMS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Banking;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel dateLabel;
        private System.Windows.Forms.ToolStripStatusLabel actionUser;
        private System.Windows.Forms.ToolStripStatusLabel StatusObjects;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ОпрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поискToolStripMenuItem1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label balanceText;
    }
}

