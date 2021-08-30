using LaboratorioNotas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaboratorioNotas.Controllers
{
    public class NotaController : Controller
    {
        // GET: Nota
        public ActionResult Notas()

        {
            using (NotasEntities1 bd = new NotasEntities1())
            {
                var ListadoNotas = bd.NotasEstudiantes.ToList();


                return View(ListadoNotas);

            }
        }
        public ActionResult save(string nombre, string labouno, string parcialuno, string labodos, string parcialdos, string labotres, string parcialtres,string NotaFinal)
        {
            using (NotasEntities1 bd = new NotasEntities1())
            {
                NotasEstudiantes emp = new NotasEstudiantes();
                emp.Nombre = nombre;
                emp.Labouno = labouno;
                emp.parcialuno = parcialuno;
                emp.Labodos = labodos;
                emp.parcialdos = parcialdos;
                emp.Labotres = labotres;
                emp.parcialtres = parcialtres;
                emp.NotaFinal = NotaFinal;


                float Final = (float) float.Parse (labouno) + float.Parse(parcialdos) + float.Parse(labodos) + float.Parse(parcialdos) + float.Parse(labotres) + float.Parse(parcialtres) / 3;
                Final = float.Parse(NotaFinal);


                bd.NotasEstudiantes.Add(emp); //este es como la funcion agregar de un crud 
                bd.SaveChanges();//con esto la base de datos reconoce los datos ingresados 

                return Redirect("/Nota/Notas"); //si hago un rediccionamiento  cuando colocamos un viewbag no lo va cargar
            }
        }
                public ActionResult RegistroNotas()
            {
            string nombre = "luis";
            ViewBag.EnviandoDatosRegistro = nombre;
                return View();
            }
              
        }

    }


 
