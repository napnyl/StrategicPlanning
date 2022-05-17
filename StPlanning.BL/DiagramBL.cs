using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StPlanning.DB;
using DevExpress.XtraEditors;
using System.Net;
using System.Reflection;

namespace StPlanning.BL
{
    public class DiagramBL
    {
        public static bool SaveDiagramLine(tblDiagramVirtual diagramVirtual)
        {
            bool result = false;
            try
            {
                MapperHelper.Register<tblDiagramVirtual, tblDiagram>();
                tblDiagram diagram = diagramVirtual.QuickMap<tblDiagramVirtual, tblDiagram>();

                using (StLiteDBEntities context = new StLiteDBEntities())
                {
                    //Se agregan los datos de diagrama.
                    context.tblDiagram.Add(diagram);

                    //Si no ocurrieron problemas, se graba en base.
                    context.SaveChanges();
                    result = true;
                }
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool DeleteDiagramLines(int idProject, int globalDiagramType)
        {
            bool result = false;
            try
            {
                using (StLiteDBEntities context = new StLiteDBEntities())
                {
                    List<tblDiagram> lines = context.tblDiagram.Where(d => d.IdProject == idProject && d.Type == globalDiagramType).ToList();
                    if (lines != null && lines.Count > 0)
                    {
                        context.tblDiagram.RemoveRange(lines);
                    }
                    //Si no ocurrieron problemas, se graba en base.
                    context.SaveChanges();
                    result = true;
                }
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static List<tblDiagramVirtual> GetDiagramLines(int idProject, int globalDiagramType)
        {
            List<tblDiagramVirtual> result = new List<tblDiagramVirtual>();
            try
            {
                using (StLiteDBEntities context = new StLiteDBEntities())
                {
                    var resultDb = context.tblDiagram.Where(d => d.IdProject == idProject && d.Type == globalDiagramType).ToList();
                    if (resultDb != null)
                    {
                        MapperHelper.Register<tblDiagram, tblDiagramVirtual>();
                        result = resultDb.QuickMap<List<tblDiagram>, List<tblDiagramVirtual>>();
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            return result;
        }
    }
}
