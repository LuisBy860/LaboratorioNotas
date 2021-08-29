using LaboratorioNotas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaboratorioNotas.Controllers
{
    public class NotasEstudiantesController : Controller
    {
        // GET: NotasEstudiantes
        public ActionResult NotasEstduiantes()
        {
            using (NotasEntities bd = new NotasEntities())
            {

                var ListadoNotas = bd.NotasEstudiantes.ToList();




                return View(ListadoNotas);
            }
        }
            public ActionResult save(string nombre, string labouno, string parcialuno, string labodos, string parcialdos, string labotres, string parcialtres)
            {
                using (NotasEntities bd = new NotasEntities())
                {
                    NotasEstudiantes emp = new NotasEstudiantes();
                    emp.Nombre = nombre;
                    emp.Labouno = labouno;
                    emp.parcialuno = parcialuno;
                    emp.Labodos = labodos;
                    emp.parcialdos = parcialdos;
                    emp.Labotres = labotres;
                    emp.parcialtres = parcialtres;

                    bd.NotasEstudiantes.Add(emp); //este es como la funcion agregar de un crud 
                    bd.SaveChanges();//con esto la base de datos reconoce los datos ingresados 

                    return View("/NotasEstudiantes/RegistroNotas"); //si hago un rediccionamiento  cuando colocamos un viewbag no lo va cargar
                }


            }
    }
}