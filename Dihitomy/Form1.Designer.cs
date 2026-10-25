namespace Dihitomy
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
      System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
      System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
      chartFunction = new System.Windows.Forms.DataVisualization.Charting.Chart();
      menuStrip1 = new MenuStrip();
      файлToolStripMenuItem = new ToolStripMenuItem();
      выходToolStripMenuItem = new ToolStripMenuItem();
      действияToolStripMenuItem = new ToolStripMenuItem();
      рассчитатьToolStripMenuItem = new ToolStripMenuItem();
      очиститьToolStripMenuItem = new ToolStripMenuItem();
      справкаToolStripMenuItem = new ToolStripMenuItem();
      оПрограммеToolStripMenuItem = new ToolStripMenuItem();
      lblA = new Label();
      lblB = new Label();
      lblE = new Label();
      lblFunction = new Label();
      lblResult = new Label();
      txtA = new TextBox();
      txtB = new TextBox();
      txtE = new TextBox();
      txtFunction = new TextBox();
      txtResult = new TextBox();
      rbDichotomy = new RadioButton();
      rbGolden = new RadioButton();
      ((System.ComponentModel.ISupportInitialize)chartFunction).BeginInit();
      menuStrip1.SuspendLayout();
      SuspendLayout();
      // 
      // chartFunction
      // 
      chartArea1.Name = "ChartArea1";
      chartFunction.ChartAreas.Add(chartArea1);
      chartFunction.Dock = DockStyle.Bottom;
      legend1.Name = "Legend1";
      chartFunction.Legends.Add(legend1);
      chartFunction.Location = new Point(0, 511);
      chartFunction.Name = "chartFunction";
      series1.ChartArea = "ChartArea1";
      series1.Legend = "Legend1";
      series1.Name = "Series1";
      chartFunction.Series.Add(series1);
      chartFunction.Size = new Size(984, 250);
      chartFunction.TabIndex = 0;
      chartFunction.Text = "chart1";
      // 
      // menuStrip1
      // 
      menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, действияToolStripMenuItem, справкаToolStripMenuItem });
      menuStrip1.Location = new Point(0, 0);
      menuStrip1.Name = "menuStrip1";
      menuStrip1.Size = new Size(984, 24);
      menuStrip1.TabIndex = 1;
      menuStrip1.Text = "menuStrip1";
      // 
      // файлToolStripMenuItem
      // 
      файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { выходToolStripMenuItem });
      файлToolStripMenuItem.Name = "файлToolStripMenuItem";
      файлToolStripMenuItem.Size = new Size(48, 20);
      файлToolStripMenuItem.Text = "Файл";
      // 
      // выходToolStripMenuItem
      // 
      выходToolStripMenuItem.Name = "выходToolStripMenuItem";
      выходToolStripMenuItem.Size = new Size(109, 22);
      выходToolStripMenuItem.Text = "Выход";
      выходToolStripMenuItem.Click += выходToolStripMenuItem_Click;
      // 
      // действияToolStripMenuItem
      // 
      действияToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { рассчитатьToolStripMenuItem, очиститьToolStripMenuItem });
      действияToolStripMenuItem.Name = "действияToolStripMenuItem";
      действияToolStripMenuItem.Size = new Size(70, 20);
      действияToolStripMenuItem.Text = "Действия";
      // 
      // рассчитатьToolStripMenuItem
      // 
      рассчитатьToolStripMenuItem.Name = "рассчитатьToolStripMenuItem";
      рассчитатьToolStripMenuItem.Size = new Size(135, 22);
      рассчитатьToolStripMenuItem.Text = "Рассчитать";
      рассчитатьToolStripMenuItem.Click += рассчитатьToolStripMenuItem_Click;
      // 
      // очиститьToolStripMenuItem
      // 
      очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
      очиститьToolStripMenuItem.Size = new Size(135, 22);
      очиститьToolStripMenuItem.Text = "Очистить";
      очиститьToolStripMenuItem.Click += очиститьToolStripMenuItem_Click;
      // 
      // справкаToolStripMenuItem
      // 
      справкаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { оПрограммеToolStripMenuItem });
      справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
      справкаToolStripMenuItem.Size = new Size(65, 20);
      справкаToolStripMenuItem.Text = "Справка";
      // 
      // оПрограммеToolStripMenuItem
      // 
      оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
      оПрограммеToolStripMenuItem.Size = new Size(149, 22);
      оПрограммеToolStripMenuItem.Text = "О программе";
      оПрограммеToolStripMenuItem.Click += оПрограммеToolStripMenuItem_Click;
      // 
      // lblA
      // 
      lblA.AutoSize = true;
      lblA.Location = new Point(59, 130);
      lblA.Name = "lblA";
      lblA.Size = new Size(24, 15);
      lblA.TabIndex = 2;
      lblA.Text = "a =";
      // 
      // lblB
      // 
      lblB.AutoSize = true;
      lblB.Location = new Point(233, 130);
      lblB.Name = "lblB";
      lblB.Size = new Size(25, 15);
      lblB.TabIndex = 3;
      lblB.Text = "b =";
      // 
      // lblE
      // 
      lblE.AutoSize = true;
      lblE.Location = new Point(59, 165);
      lblE.Name = "lblE";
      lblE.Size = new Size(78, 15);
      lblE.TabIndex = 4;
      lblE.Text = "Точность e =";
      // 
      // lblFunction
      // 
      lblFunction.AutoSize = true;
      lblFunction.Location = new Point(59, 202);
      lblFunction.Name = "lblFunction";
      lblFunction.Size = new Size(36, 15);
      lblFunction.TabIndex = 5;
      lblFunction.Text = "f(x) =";
      // 
      // lblResult
      // 
      lblResult.AutoSize = true;
      lblResult.Location = new Point(59, 296);
      lblResult.Name = "lblResult";
      lblResult.Size = new Size(63, 15);
      lblResult.TabIndex = 6;
      lblResult.Text = "Результат:";
      // 
      // txtA
      // 
      txtA.Location = new Point(89, 127);
      txtA.Name = "txtA";
      txtA.Size = new Size(100, 23);
      txtA.TabIndex = 7;
      // 
      // txtB
      // 
      txtB.Location = new Point(264, 127);
      txtB.Name = "txtB";
      txtB.Size = new Size(100, 23);
      txtB.TabIndex = 8;
      // 
      // txtE
      // 
      txtE.Location = new Point(143, 165);
      txtE.Name = "txtE";
      txtE.Size = new Size(100, 23);
      txtE.TabIndex = 9;
      // 
      // txtFunction
      // 
      txtFunction.Location = new Point(101, 199);
      txtFunction.Name = "txtFunction";
      txtFunction.Size = new Size(200, 23);
      txtFunction.TabIndex = 10;
      // 
      // txtResult
      // 
      txtResult.Location = new Point(59, 330);
      txtResult.Multiline = true;
      txtResult.Name = "txtResult";
      txtResult.ReadOnly = true;
      txtResult.Size = new Size(700, 150);
      txtResult.TabIndex = 11;
      // 
      // rbDichotomy
      // 
      rbDichotomy.AutoSize = true;
      rbDichotomy.Checked = true;
      rbDichotomy.Location = new Point(59, 86);
      rbDichotomy.Name = "rbDichotomy";
      rbDichotomy.Size = new Size(167, 19);
      rbDichotomy.TabIndex = 12;
      rbDichotomy.TabStop = true;
      rbDichotomy.Text = "Поиск корня (дихотомия)";
      rbDichotomy.UseVisualStyleBackColor = true;
      // 
      // rbGolden
      // 
      rbGolden.AutoSize = true;
      rbGolden.Location = new Point(233, 86);
      rbGolden.Name = "rbGolden";
      rbGolden.Size = new Size(226, 19);
      rbGolden.TabIndex = 13;
      rbGolden.Text = "Поиск минимума (золотое сечение)";
      rbGolden.UseVisualStyleBackColor = true;
      // 
      // Form1
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(984, 761);
      Controls.Add(rbGolden);
      Controls.Add(rbDichotomy);
      Controls.Add(txtResult);
      Controls.Add(txtFunction);
      Controls.Add(txtE);
      Controls.Add(txtB);
      Controls.Add(txtA);
      Controls.Add(lblResult);
      Controls.Add(lblFunction);
      Controls.Add(lblE);
      Controls.Add(lblB);
      Controls.Add(lblA);
      Controls.Add(chartFunction);
      Controls.Add(menuStrip1);
      MainMenuStrip = menuStrip1;
      Name = "Form1";
      Text = "Расчитать по методу дихотомии";
      ((System.ComponentModel.ISupportInitialize)chartFunction).EndInit();
      menuStrip1.ResumeLayout(false);
      menuStrip1.PerformLayout();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private System.Windows.Forms.DataVisualization.Charting.Chart chartFunction;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem файлToolStripMenuItem;
    private ToolStripMenuItem действияToolStripMenuItem;
    private ToolStripMenuItem справкаToolStripMenuItem;
    private ToolStripMenuItem рассчитатьToolStripMenuItem;
    private ToolStripMenuItem очиститьToolStripMenuItem;
    private ToolStripMenuItem оПрограммеToolStripMenuItem;
    private Label lblA;
    private Label lblB;
    private Label lblE;
    private Label lblFunction;
    private Label lblResult;
    private TextBox txtA;
    private TextBox txtB;
    private TextBox txtE;
    private TextBox txtFunction;
    private TextBox txtResult;
    private ToolStripMenuItem выходToolStripMenuItem;
    private RadioButton rbDichotomy;
    private RadioButton rbGolden;
  }
}
