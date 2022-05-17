using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Crainiate.Diagramming;
using DevExpress.XtraEditors;
using Crainiate.Diagramming.Forms;

namespace StPlanning.WorkFlow.Forms
{
    public partial class frmDiagramTest : Form
    {
        float objectsWidth = 125;
        float objectsHeight = 110;
        float objectsSpace = 20;
        float objectsWidthSpace = 40;
        int textInObject = 19;
        string financialType = "Financiero";
        string clientType = "Cliente";
        string processType = "Proceso";
        string growthType = "A. y C.";
        List<Strategies> globalStrategies = new List<Strategies>();

        Color financialGColor = Color.FromArgb(96, SystemColors.Highlight);
        Color financialBColor = Color.FromArgb(223, SystemColors.Highlight);
        Color clientGColor = Color.FromArgb(128, Color.GreenYellow);
        Color clientBColor = Color.FromArgb(255, Color.GreenYellow);
        Color processGColor = Color.FromArgb(128, Color.Brown);
        Color processBColor = Color.FromArgb(255, Color.Brown);
        Color growthGColor = Color.FromArgb(128, Color.Gray);
        Color growthBColor = Color.FromArgb(255, Color.Gray);

        int oldFinancialMaxHeight = 0;
        int oldClientMaxHeight = 0;
        int oldProcessMaxHeight = 0;

        int financialMaxHeight = 0;
        int clientMaxHeight = 0;
        int processMaxHeight = 0;

        int financialObjects = 0;
        int clientObjects = 0;
        int processObjects = 0;
        int growthObjects = 0;

        int objectsNum = 0;
        Model model = new Model();
        public bool stShown = false;
        public string errorMessage = string.Empty;
        Connector currentConnector = new Connector();
        

        public frmDiagramTest()
        {
            InitializeComponent();
            try
            {
                globalStrategies = LoadStrategies();
                diagram1.Controller.Model = LoadModelPrivate();
                diagram1.Controller.Refresh();
                stShown = true;
            }
            catch (Exception ex)
            {
                stShown = false;
                errorMessage = ex.Message + ", " + ex.InnerException.Message;
            }
        }

        private List<Strategies> LoadStrategies()
        {
            List<Strategies> strategies = new List<Strategies>();

            var strategy = new Strategies();
            strategy.Type = financialType;
            strategy.Strategy = "Estrategia de perspectiva financiero 1";
            strategies.Add(strategy);

            strategy = new Strategies();
            strategy.Type = financialType;
            strategy.Strategy = "Estrategia de perspectiva financiero 2";
            strategies.Add(strategy);

            strategy = new Strategies();
            strategy.Type = financialType;
            strategy.Strategy = "Estrategia de perspectiva financiero 3";
            strategies.Add(strategy);

            strategy = new Strategies();
            strategy.Type = clientType;
            strategy.Strategy = "Estrategia de perspectiva cliente 1";
            strategies.Add(strategy);

            strategy = new Strategies();
            strategy.Type = clientType;
            strategy.Strategy = "Estrategia de perspectiva cliente 2";
            strategies.Add(strategy);

            strategy = new Strategies();
            strategy.Type = clientType;
            strategy.Strategy = "Estrategia de perspectiva cliente 3";
            strategies.Add(strategy);

            strategy = new Strategies();
            strategy.Type = processType;
            strategy.Strategy = "Estrategia de perspectiva proceso 1";
            strategies.Add(strategy);

            strategy = new Strategies();
            strategy.Type = processType;
            strategy.Strategy = "Estrategia de perspectiva proceso 2";
            strategies.Add(strategy);

            strategy = new Strategies();
            strategy.Type = processType;
            strategy.Strategy = "Estrategia de perspectiva proceso 3";
            strategies.Add(strategy);

            strategy = new Strategies();
            strategy.Type = growthType;
            strategy.Strategy = "Estrategia de perspectiva aprendizaje 1";
            strategies.Add(strategy);

            strategy = new Strategies();
            strategy.Type = growthType;
            strategy.Strategy = "Estrategia de perspectiva aprendizaje 2";
            strategies.Add(strategy);

            strategy = new Strategies();
            strategy.Type = growthType;
            strategy.Strategy = "Estrategia de perspectiva aprendizaje 3";
            strategies.Add(strategy);

            return strategies;
        }

        private Model LoadModelPrivate()
        {
            Table table = new Table();
            TableRow row = new TableRow();

            var theme = new Theme();
            theme.BackColor = Color.White;
            model.ApplyTheme(theme);

            //Modelo de empresa privada:
            //1. Financiero
            //2. Cliente
            //3. Proceso interno
            //4. Aprendizaje y Crecimiento
            foreach (var strategy in globalStrategies)
            {
                table = new Table();
                table.Width = objectsWidth;
                table.Height = objectsHeight;
                table.Indent = 10;
                table.DrawExpand = true;

                if (strategy.Type == financialType)
                {
                    table.Location = new PointF((financialObjects * objectsWidth) + (financialObjects * objectsWidthSpace) + objectsSpace, objectsSpace);
                    table.Heading = financialType;
                    table.SubHeading = financialType;
                    table.GradientColor = financialGColor;
                    table.BorderColor = financialBColor;

                    string objectDesc = strategy.Strategy;
                    while (objectDesc.Length > textInObject || objectDesc.Length > 0)
                    {
                        row = new TableRow();
                        if (objectDesc.Length > textInObject)
                        {
                            row.Text = objectDesc.Substring(0, textInObject);
                            objectDesc = objectDesc.Replace(objectDesc.Substring(0, textInObject), "");
                        }
                        else
                        {
                            row.Text = objectDesc;
                            objectDesc = string.Empty;
                        }

                        table.Rows.Add(row);
                        financialMaxHeight++;
                    }

                    if (financialMaxHeight > oldFinancialMaxHeight)
                        oldFinancialMaxHeight = financialMaxHeight;

                    financialMaxHeight = 0;
                    financialObjects++;
                }
                else if (strategy.Type == clientType)
                {
                    table.Location = new PointF((clientObjects * objectsWidth) + (clientObjects * objectsWidthSpace) + objectsSpace, (oldFinancialMaxHeight * objectsSpace) + objectsHeight);
                    table.Heading = clientType;
                    table.SubHeading = clientType;
                    table.GradientColor = clientGColor;
                    table.BorderColor = clientBColor;

                    string objectDesc = strategy.Strategy;
                    while (objectDesc.Length > textInObject || objectDesc.Length > 0)
                    {
                        row = new TableRow();
                        if (objectDesc.Length > textInObject)
                        {
                            row.Text = objectDesc.Substring(0, textInObject);
                            objectDesc = objectDesc.Replace(objectDesc.Substring(0, textInObject), "");
                        }
                        else
                        {
                            row.Text = objectDesc;
                            objectDesc = string.Empty;
                        }

                        table.Rows.Add(row);
                        clientMaxHeight++;
                    }

                    if (clientMaxHeight > oldClientMaxHeight)
                        oldClientMaxHeight = clientMaxHeight;

                    clientMaxHeight = 0;
                    clientObjects++;
                }
                else if (strategy.Type == processType)
                {
                    table.Location = new PointF((processObjects * objectsWidth) + (processObjects * objectsWidthSpace) + objectsSpace, (oldFinancialMaxHeight * objectsSpace) + (oldClientMaxHeight * objectsSpace) + (2 * objectsHeight));
                    table.Heading = processType;
                    table.SubHeading = processType;
                    table.GradientColor = processGColor;
                    table.BorderColor = processBColor;

                    string objectDesc = strategy.Strategy;
                    while (objectDesc.Length > textInObject || objectDesc.Length > 0)
                    {
                        row = new TableRow();
                        if (objectDesc.Length > textInObject)
                        {
                            row.Text = objectDesc.Substring(0, textInObject);
                            objectDesc = objectDesc.Replace(objectDesc.Substring(0, textInObject), "");
                        }
                        else
                        {
                            row.Text = objectDesc;
                            objectDesc = string.Empty;
                        }

                        table.Rows.Add(row);
                        processMaxHeight++;
                    }

                    if (processMaxHeight > oldProcessMaxHeight)
                        oldProcessMaxHeight = processMaxHeight;

                    processMaxHeight = 0;
                    processObjects++;
                }
                else if (strategy.Type == growthType)
                {
                    table.Location = new PointF((growthObjects * objectsWidth) + (growthObjects * objectsWidthSpace) + objectsSpace, (oldFinancialMaxHeight * objectsSpace) + (oldClientMaxHeight * objectsSpace) + (oldProcessMaxHeight * objectsSpace) + (3 * objectsHeight));
                    table.Heading = growthType;
                    table.SubHeading = growthType;
                    table.GradientColor = growthGColor;
                    table.BorderColor = growthBColor;

                    string objectDesc = strategy.Strategy;
                    while (objectDesc.Length > textInObject || objectDesc.Length > 0)
                    {
                        row = new TableRow();
                        if (objectDesc.Length > textInObject)
                        {
                            row.Text = objectDesc.Substring(0, textInObject);
                            objectDesc = objectDesc.Replace(objectDesc.Substring(0, textInObject), "");
                        }
                        else
                        {
                            row.Text = objectDesc;
                            objectDesc = string.Empty;
                        }

                        table.Rows.Add(row);
                    }

                    growthObjects++;
                }

                objectsNum++;
                model.Shapes.Add("Object" + objectsNum, table);
            }

            #region Creación de flecha y líneas

            ////Create an arrow line marker
            //Arrow arrow = new Arrow();
            //arrow.DrawBackground = false;
            //arrow.Inset = 8;

            ////Add link between shape and solid
            //Connector line = new Connector(model.Shapes["Shape"], model.Shapes["SolidElement"]);
            //line.End.Marker = arrow;
            //model.Lines.Add(model.Lines.CreateKey(), line);

            ////Add link between solid and element
            //line = new Connector(model.Shapes["SolidElement"], model.Shapes["Element"]);
            //line.End.Marker = arrow;
            //model.Lines.Add(model.Lines.CreateKey(), line);

            //line = new Connector(model.Shapes["Element"], model.Shapes["Layer"]);
            //line.End.Marker = arrow;
            //model.Lines.Add(model.Lines.CreateKey(), line);

            #endregion Creación de flecha y líneas

            //Set the default style for elements in the diagram
            //var theme = new Theme();
            //theme.GradientColor = Color.FromArgb(96, SystemColors.Highlight);
            //theme.BorderColor = Color.FromArgb(223, SystemColors.Highlight);
            //theme.BackColor = Color.White;
            //model.ApplyTheme(theme);

            return model;
        }

        //Modelo de empresa privada:
        //1. Cliente
        //2. Proceso interno
        //3. Aprendizaje y Crecimiento
        //4. Financiero
        private Model LoadModelPublic()
        {
            Table table = new Table();
            TableRow row = new TableRow();

            var theme = new Theme();
            theme.BackColor = Color.White;
            model.ApplyTheme(theme);

            foreach (var strategy in globalStrategies)
            {
                table = new Table();
                table.Width = objectsWidth;
                table.Height = objectsHeight;
                table.Indent = 10;
                table.DrawExpand = true;

                if (strategy.Type == financialType)
                {
                    table.Location = new PointF((financialObjects * objectsWidth) + (financialObjects * objectsWidthSpace) + objectsSpace, objectsSpace);
                    table.Heading = financialType;
                    table.SubHeading = financialType;
                    table.GradientColor = financialGColor;
                    table.BorderColor = financialBColor;

                    string objectDesc = strategy.Strategy;
                    while (objectDesc.Length > textInObject || objectDesc.Length > 0)
                    {
                        row = new TableRow();
                        if (objectDesc.Length > textInObject)
                        {
                            row.Text = objectDesc.Substring(0, textInObject);
                            objectDesc = objectDesc.Replace(objectDesc.Substring(0, textInObject), "");
                        }
                        else
                        {
                            row.Text = objectDesc;
                            objectDesc = string.Empty;
                        }

                        table.Rows.Add(row);
                        financialMaxHeight++;
                    }

                    if (financialMaxHeight > oldFinancialMaxHeight)
                        oldFinancialMaxHeight = financialMaxHeight;

                    financialMaxHeight = 0;
                    financialObjects++;
                }
                else if (strategy.Type == clientType)
                {
                    table.Location = new PointF((clientObjects * objectsWidth) + (clientObjects * objectsWidthSpace) + objectsSpace, (oldFinancialMaxHeight * objectsSpace) + objectsHeight);
                    table.Heading = clientType;
                    table.SubHeading = clientType;
                    table.GradientColor = clientGColor;
                    table.BorderColor = clientBColor;

                    string objectDesc = strategy.Strategy;
                    while (objectDesc.Length > textInObject || objectDesc.Length > 0)
                    {
                        row = new TableRow();
                        if (objectDesc.Length > textInObject)
                        {
                            row.Text = objectDesc.Substring(0, textInObject);
                            objectDesc = objectDesc.Replace(objectDesc.Substring(0, textInObject), "");
                        }
                        else
                        {
                            row.Text = objectDesc;
                            objectDesc = string.Empty;
                        }

                        table.Rows.Add(row);
                        clientMaxHeight++;
                    }

                    if (clientMaxHeight > oldClientMaxHeight)
                        oldClientMaxHeight = clientMaxHeight;

                    clientMaxHeight = 0;
                    clientObjects++;
                }
                else if (strategy.Type == processType)
                {
                    table.Location = new PointF((processObjects * objectsWidth) + (processObjects * objectsWidthSpace) + objectsSpace, (oldFinancialMaxHeight * objectsSpace) + (oldClientMaxHeight * objectsSpace) + (2 * objectsHeight));
                    table.Heading = processType;
                    table.SubHeading = processType;
                    table.GradientColor = processGColor;
                    table.BorderColor = processBColor;

                    string objectDesc = strategy.Strategy;
                    while (objectDesc.Length > textInObject || objectDesc.Length > 0)
                    {
                        row = new TableRow();
                        if (objectDesc.Length > textInObject)
                        {
                            row.Text = objectDesc.Substring(0, textInObject);
                            objectDesc = objectDesc.Replace(objectDesc.Substring(0, textInObject), "");
                        }
                        else
                        {
                            row.Text = objectDesc;
                            objectDesc = string.Empty;
                        }

                        table.Rows.Add(row);
                        processMaxHeight++;
                    }

                    if (processMaxHeight > oldProcessMaxHeight)
                        oldProcessMaxHeight = processMaxHeight;

                    processMaxHeight = 0;
                    processObjects++;
                }
                else if (strategy.Type == growthType)
                {
                    table.Location = new PointF((growthObjects * objectsWidth) + (growthObjects * objectsWidthSpace) + objectsSpace, (oldFinancialMaxHeight * objectsSpace) + (oldClientMaxHeight * objectsSpace) + (oldProcessMaxHeight * objectsSpace) + (3 * objectsHeight));
                    table.Heading = growthType;
                    table.SubHeading = growthType;
                    table.GradientColor = growthGColor;
                    table.BorderColor = growthBColor;

                    string objectDesc = strategy.Strategy;
                    while (objectDesc.Length > textInObject || objectDesc.Length > 0)
                    {
                        row = new TableRow();
                        if (objectDesc.Length > textInObject)
                        {
                            row.Text = objectDesc.Substring(0, textInObject);
                            objectDesc = objectDesc.Replace(objectDesc.Substring(0, textInObject), "");
                        }
                        else
                        {
                            row.Text = objectDesc;
                            objectDesc = string.Empty;
                        }

                        table.Rows.Add(row);
                    }

                    growthObjects++;
                }

                objectsNum++;
                model.Shapes.Add("Object" + objectsNum, table);
            }

            return model;
        }

        private void btnGenerateArrow_Click(object sender, EventArgs e)
        {
            //Create an arrow line marker
            Arrow arrow = new Arrow();
            arrow.DrawBackground = false;
            arrow.Inset = 8;
            arrow.BorderColor = Color.FromArgb(223, cpeArrow.Color); //Color.FromArgb(223, SystemColors.Highlight);

            //Add link between shape and solid
            Connector line = new Connector(new PointF(0, objectsSpace / 2), new PointF(objectsWidthSpace, objectsSpace / 2));
            line.BorderColor = Color.FromArgb(223, cpeArrow.Color);
            line.End.Marker = arrow;
            model.Lines.Add(model.Lines.CreateKey(), line);

            diagram1.Refresh();
        }
        private void frmDiagramTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)// && !Main.closeFromMain)
            {
                if (XtraMessageBox.Show("¿Está seguro que desea cerrar el diagrama actual? Se perderan los datos!", "Confirmación", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void frmDiagramTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((DevExpress.XtraBars.Ribbon.RibbonControl)(this.Parent.TopLevelControl.Controls["ribbonControl1"])).Items["btnPrivateDiagram"].Enabled = true;
            //Main.projectSaved = false;
        }

        private void diagram1_SelectedChanged(object sender, EventArgs e)
        {
            if (((Crainiate.Diagramming.Forms.View)(sender)).CurrentMouseElements.MouseMoveSelectable is Connector)
                currentConnector = (((Crainiate.Diagramming.Forms.View)(sender)).CurrentMouseElements.MouseMoveSelectable as Connector);
            else
                currentConnector = null;
        }

        private void diagram1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back && currentConnector != null && model.Lines.Count > 0)
            {
                model.Elements.Remove(currentConnector);
                model.Lines.Remove(currentConnector.Key);
                diagram1.Refresh();
            }
        }

        private void diagram1_BeginDragSelect(object sender, MouseEventArgs e)
        {
            var a = e.Location.X;
            var b = e.Location.Y;

        }
    }
}
