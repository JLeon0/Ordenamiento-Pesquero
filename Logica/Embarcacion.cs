﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Embarcacion
    {
        public string Nombre { get; set; }
        public string Matricula { get; set; }
        public string REGISTRONUM { get; set; }
        public string RNP { get; set; }
        public string RNPATITULAR { get; set; }
        public string FECHAEXP { get; set; }
        public string FECHACHIPEADO { get; set; }
        public string MARCA { get; set; }
        public string HP { get; set; }
        public string ESLORA { get; set; }
        public string MUNICIPIO { get; set; }
        public string MANGA { get; set; }
        public string PUNTAL { get; set; }
        public string ARQUEOBRUTO { get; set; }
        public string ARQUEONETO { get; set; }
        public string TONELAJE { get; set; }
        public string OBSERVACIONES { get; set; }
        public string NCHIP { get; set; }
        public string RESPCHIP { get; set; }
        public string SERVICIO { get; set; }
        public string TRAFICO { get; set; }
        public string NMOTORES { get; set; }
        public string CAPITAN { get; set; }
        public string MARINERO { get; set; }

        public Embarcacion()
        {
            Nombre = "";
            Matricula = "";
            REGISTRONUM = "";
            RNPATITULAR = "";
            FECHAEXP = "";
            FECHACHIPEADO = "";
            MARCA = "";
            HP = "";
            ESLORA = "";
            MUNICIPIO = "";
            MANGA = "";
            PUNTAL = "";
            ARQUEOBRUTO = "";
            ARQUEONETO = "";
            TONELAJE = "";
            OBSERVACIONES = "";
            RNP = "";
            NCHIP = "";
            RESPCHIP = "";
            CAPITAN = "";
            MARINERO = "";
        }
        public Embarcacion(string nombre, string matricula, string hp, string marca, string municipio, string rnpa)
        {
            Nombre = nombre;
            Matricula = matricula;
            REGISTRONUM = "";
            RNPATITULAR = rnpa;
            FECHAEXP = "";
            FECHACHIPEADO = "";
            MARCA = marca;
            HP = hp;
            ESLORA = "";
            MUNICIPIO = municipio;
            MANGA = "";
            PUNTAL = "";
            ARQUEOBRUTO = "";
            ARQUEONETO = "";
            TONELAJE = "";
            OBSERVACIONES = "";
            RNP = "";
        }
        public Embarcacion(string nombre,string matricula,string rNPA,string mARCA,string hP,string mUNICIPIO,
        string rEGISTRONUM,string fECHACHIPEADO,string fECHAEXP,string eSLORA,string mANGA,string pUNTAL,string aRQUEOBRUTO,
        string aRQUEONETO,string tONELAJE,string oBSERVACIONES,string rNP)
        {
            Nombre = nombre;
            Matricula = matricula;
            RNPATITULAR = rNPA;
            MARCA = mARCA;
            HP = hP;
            MUNICIPIO = mUNICIPIO;
            REGISTRONUM = rEGISTRONUM;
            FECHAEXP = fECHAEXP;
            FECHACHIPEADO =fECHACHIPEADO;
            ESLORA = eSLORA;
            MANGA = mANGA;
            PUNTAL = pUNTAL;
            ARQUEOBRUTO = aRQUEOBRUTO;
            ARQUEONETO = aRQUEONETO;
            TONELAJE = tONELAJE;
            OBSERVACIONES = oBSERVACIONES;
            RNP = rNP;
        }

        public Embarcacion(string nombre, string matricula, string rnpa, string hp, string eslora, string manga, string puntal,
            string arqueobruto, string arqueoneto, string tonelaje, string servicio, string trafico, string Nmotores, string nchip, 
            string fchip, string rchip, string regnum, string fexp, string capitan, string marinero)
        {
            Nombre = nombre;
            Matricula = matricula;
            RNPATITULAR = rnpa;
            HP = hp;
            ESLORA = eslora;
            MANGA = manga;
            PUNTAL = puntal;
            ARQUEOBRUTO = arqueobruto;
            ARQUEONETO = arqueoneto;
            TONELAJE = tonelaje;
            SERVICIO = servicio;
            TRAFICO = trafico;
            NMOTORES = Nmotores;
            NCHIP = nchip;
            FECHACHIPEADO = fchip;
            RESPCHIP = rchip;
            REGISTRONUM = regnum;
            FECHAEXP = fexp;
            CAPITAN = capitan;
            MARINERO = marinero;
        }
    }
}
