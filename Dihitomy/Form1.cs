using System;
using System.Windows.Forms;
using NCalc;
using System.Globalization;

using System.Windows.Forms.DataVisualization.Charting;

namespace Dihitomy
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    // ============ РАССЧИТАТЬ ============
    private void рассчитатьToolStripMenuItem_Click(object sender, EventArgs e)
    {
      double a;
      double b;
      double epsilon;

      if (!double.TryParse(txtA.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out a))
      {
        MessageBox.Show("Поле 'a' должно быть числом.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      if (!double.TryParse(txtB.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out b))
      {
        MessageBox.Show("Поле 'b' должно быть числом.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      if (!double.TryParse(txtE.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out epsilon))
      {
        MessageBox.Show("Поле 'e' должно быть числом.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      if (a >= b)
      {
        MessageBox.Show("Значение 'a' должно быть меньше 'b'.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      if (epsilon <= 0)
      {
        MessageBox.Show("Точность 'e' должна быть больше нуля.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      string formula = txtFunction.Text.Trim();

      if (string.IsNullOrWhiteSpace(formula))
      {
        MessageBox.Show("Введите формулу f(x).", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      double fa;
      double fb;

      if (!TryEvaluate(formula, a, out fa))
      {
        MessageBox.Show("Не удалось вычислить f(a). Проверьте формулу.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      if (!TryEvaluate(formula, b, out fb))
      {
        MessageBox.Show("Не удалось вычислить f(b). Проверьте формулу.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      if (fa * fb > 0)
      {
        MessageBox.Show("На этом интервале функция не меняет знак. f(a) и f(b) одного знака.",
                        "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      double left = a;
      double right = b;

      while ((right - left) / 2.0 > epsilon)
      {
        double middle = (left + right) / 2.0;

        double fm;
        if (!TryEvaluate(formula, middle, out fm))
        {
          MessageBox.Show("Ошибка при вычислении f(x).", "Ошибка",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }

        if (fa * fm < 0)
        {
          right = middle;
        }
        else
        {
          left = middle;
        }
      }

      double root = (left + right) / 2.0;
      double fRoot;
      TryEvaluate(formula, root, out fRoot);

      txtResult.Text =
        "=== Результат ===\r\n" +
        $"Формула: f(x) = {formula}\r\n" +
        $"Интервал: [{a}; {b}]\r\n" +
        $"Точность: {epsilon}\r\n" +
        $"f(a) = {fa:F4}\r\n" +
        $"f(b) = {fb:F4}\r\n" +
        "\r\n" +
        $"Корень: x = {root:F6}\r\n" +
        $"f(x) = {fRoot:F6}\r\n" +
        $"Проверка: |f(x)| ≤ e → {(Math.Abs(fRoot) <= epsilon ? "да" : "нет")}";

      DrawChart(formula, a, b, root);
    }

    // ============ ОЧИСТИТЬ ============
    private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
    {
      txtA.Text = "";
      txtB.Text = "";
      txtE.Text = "";
      txtFunction.Text = "";
      txtResult.Text = "";

      chartFunction.Series.Clear();
      chartFunction.ChartAreas.Clear();
      chartFunction.Titles.Clear();
    }

    // ============ О ПРОГРАММЕ ============
    private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
    {
      MessageBox.Show(
        "Лабораторная работа: метод половинного деления\r\n" +
        "Поиск точки смены знака функции на интервале.\r\n" +
        "© 2026",
        "О программе",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);
    }

    // ============ ВЫЧИСЛЕНИЕ ФОРМУЛЫ ============
    private bool TryEvaluate(string formula, double x, out double result)
    {
      result = 0;

      try
      {
        Expression expression = new Expression(formula);
        expression.Parameters["x"] = x;

        object value = expression.Evaluate();

        if (value == null) return false;

        result = Convert.ToDouble(value);
        return !double.IsNaN(result) && !double.IsInfinity(result);
      }
      catch
      {
        return false;
      }
    }

    // ============ ГРАФИК ============
    private void DrawChart(string formula, double a, double b, double root)
    {
      chartFunction.Series.Clear();
      chartFunction.ChartAreas.Clear();
      chartFunction.Titles.Clear();

      ChartArea area = new ChartArea("MainArea");
      area.AxisX.Title = "x";
      area.AxisY.Title = "f(x)";
      area.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
      area.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
      chartFunction.ChartAreas.Add(area);

      Series functionSeries = new Series("f(x)");
      functionSeries.ChartType = SeriesChartType.Line;
      functionSeries.Color = System.Drawing.Color.Blue;
      functionSeries.BorderWidth = 2;

      int pointCount = 200;
      double step = (b - a) / pointCount;

      for (int i = 0; i <= pointCount; i++)
      {
        double x = a + i * step;

        double y;
        if (TryEvaluate(formula, x, out y))
        {
          functionSeries.Points.AddXY(x, y);
        }
      }

      chartFunction.Series.Add(functionSeries);

      Series rootSeries = new Series("Корень");
      rootSeries.ChartType = SeriesChartType.Point;
      rootSeries.Color = System.Drawing.Color.Red;
      rootSeries.MarkerStyle = MarkerStyle.Circle;
      rootSeries.MarkerSize = 12;

      double rootY;
      if (TryEvaluate(formula, root, out rootY))
      {
        rootSeries.Points.AddXY(root, rootY);
      }

      chartFunction.Series.Add(rootSeries);
      chartFunction.Titles.Add($"f(x) = {formula}, корень при x = {root:F4}");
    }

    private void выходToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }
  }
}
