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

    private void рассчитатьToolStripMenuItem_Click(object sender, EventArgs e)
    {
      // 1. Сбор и проверка данных
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

      // 2. Выбор метода
      if (rbDichotomy.Checked)
      {
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
        double root = 0;
        bool foundExact = false;

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

          if (Math.Abs(fm) < epsilon)
          {
            root = middle;
            foundExact = true;
            break;
          }

          if (fa * fm < 0)
          {
            right = middle;
          }
          else
          {
            left = middle;
            fa = fm;
          }
        }

        if (!foundExact)
        {
          root = (left + right) / 2.0;
        }

        double fRoot;
        TryEvaluate(formula, root, out fRoot);

        txtResult.Text =
          "=== Результат (Дихотомия) ===\r\n" +
          $"Формула: f(x) = {formula}\r\n" +
          $"Интервал: [{a}; {b}]\r\n" +
          $"Точность: {epsilon}\r\n" +
          $"f(a) = {fa:F4}\r\n" +
          $"f(b) = {fb:F4}\r\n" +
          "\r\n" +
          $"Корень: x = {root:F6}\r\n" +
          $"f(x) = {fRoot:F6}\r\n" +
          $"Проверка: |f(x)| ≤ e → {(Math.Abs(fRoot) <= epsilon ? "да" : "нет")}";

        DrawChart(formula, a, b, root, "Корень");
      }
      else if (rbGolden.Checked)
      {
        FindMinimum(formula, a, b, epsilon);
      }
      else
      {
        MessageBox.Show("Выберите метод расчета.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      }
    }

    private void FindMinimum(string formula, double a, double b, double epsilon)
    {
      double phi = (1 + Math.Sqrt(5)) / 2.0;

      double left = a;
      double right = b;

      double x1 = right - (right - left) / phi;
      double x2 = left + (right - left) / phi;

      double f1, f2;
      if (!TryEvaluate(formula, x1, out f1) || !TryEvaluate(formula, x2, out f2))
      {
        MessageBox.Show("Ошибка при вычислении функции. Проверьте формулу.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      while ((right - left) > epsilon)
      {
        if (f1 < f2)
        {
          right = x2;
          x2 = x1;
          f2 = f1;

          x1 = right - (right - left) / phi;
          if (!TryEvaluate(formula, x1, out f1)) return;
        }
        else
        {
          left = x1;
          x1 = x2;
          f1 = f2;

          x2 = left + (right - left) / phi;
          if (!TryEvaluate(formula, x2, out f2)) return;
        }
      }

      double xMin = (left + right) / 2.0;
      double fMin;
      if (!TryEvaluate(formula, xMin, out fMin))
      {
        MessageBox.Show("Ошибка вычисления в точке минимума.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      txtResult.Text =
        "=== Результат (Золотое сечение) ===\r\n" +
        $"Формула: f(x) = {formula}\r\n" +
        $"Интервал: [{a}; {b}]\r\n" +
        $"Точность: {epsilon}\r\n" +
        "\r\n" +
        $"Точка минимума: x = {xMin:F6}\r\n" +
        $"Минимальное значение: f(x) = {fMin:F6}\r\n" +
        $"Финальный интервал: [{left:F6}; {right:F6}]\r\n";

      DrawChart(formula, a, b, xMin, "Минимум");
    }

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

    private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
    {
      MessageBox.Show(
        "Лабораторная работа: методы поиска\r\n" +
        "Дихотомия и Золотое сечение.\r\n" +
        "© 2026",
        "О программе",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);
    }

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

    private void DrawChart(string formula, double a, double b, double pointX, string pointLabel)
    {
      chartFunction.Series.Clear();
      chartFunction.ChartAreas.Clear();
      chartFunction.Titles.Clear();
      chartFunction.Legends.Clear();

      ChartArea area = new ChartArea("MainArea");
      area.AxisX.Title = "x";
      area.AxisY.Title = "f(x)";
      area.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
      area.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
      area.AxisY.IsStartedFromZero = false;
      chartFunction.ChartAreas.Add(area);

      Series functionSeries = new Series("f(x)");
      functionSeries.ChartType = SeriesChartType.Line;
      functionSeries.Color = System.Drawing.Color.Blue;
      functionSeries.BorderWidth = 2;

      double yLimit = 20;

      int pointCount = 2000;
      double step = (b - a) / pointCount;

      for (int i = 0; i <= pointCount; i++)
      {
        double x = a + i * step;
        double y;

        if (TryEvaluate(formula, x, out y))
        {
          if (Math.Abs(y) <= yLimit)
          {
            functionSeries.Points.AddXY(x, y);
          }
          else
          {
            functionSeries.Points.AddXY(x, double.NaN);
          }
        }
        else
        {
          functionSeries.Points.AddXY(x, double.NaN);
        }
      }

      chartFunction.Series.Add(functionSeries);

      Series rootSeries = new Series(pointLabel);
      rootSeries.ChartType = SeriesChartType.Point;
      rootSeries.Color = System.Drawing.Color.Red;
      rootSeries.MarkerStyle = MarkerStyle.Circle;
      rootSeries.MarkerSize = 12;

      double rootY;
      if (TryEvaluate(formula, pointX, out rootY))
      {
        if (Math.Abs(rootY) <= yLimit)
        {
          rootSeries.Points.AddXY(pointX, rootY);
        }
      }

      chartFunction.Series.Add(rootSeries);
      chartFunction.Titles.Add($"f(x) = {formula}, {pointLabel} при x = {pointX:F4}");
    }

    private void выходToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }
  }
}