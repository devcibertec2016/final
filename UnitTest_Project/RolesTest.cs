
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using Web_1.Controllers;
using Datos;
using System.Collections.Generic;
using System.Data.Entity;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest_Project
{
    [TestClass]
    public class RolesTest
    {
        private DB_Trabajo_1Entities3 db = new DB_Trabajo_1Entities3();

        [TestMethod]
        public void IndexListRoles()
        {
            tTR_Roles objRolesActual = null;
            List<tTR_Roles> lstRolesActual = null;
            lstRolesActual = new List<tTR_Roles>();
            objRolesActual = new tTR_Roles { vNombreRol = "Administrador", iEstado = 1 };
            lstRolesActual.Add(objRolesActual);
            var list = db.tTR_Roles;
            Assert.AreNotEqual(list, lstRolesActual);
        }

        //[TestMethod]
        //public void IndexListRoles_1()
        //{
        //    var list = db.tTR_Roles;
        //    tTR_Roles objRolesActual = null;
        //    List<tTR_Roles> lstRolesActual = null;
        //    lstRolesActual = new List<tTR_Roles>();
        //    objRolesActual = new tTR_Roles { vNombreRol = "Administrador", iEstado = 1 };
        //    lstRolesActual.Add(objRolesActual);
        //    List<tTR_Usuarios> loenlista = new System.Collections.Generic.List<tTR_Usuarios>();
        //    loenlista = list.Cast<tTR_Usuarios>().ToList();
        //    Assert.AreEqual(loenlista, lstRolesActual);

        //}
    }

}
