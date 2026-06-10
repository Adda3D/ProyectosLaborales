using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.DTO
{
    public class DecVie_PreAvalRevisionDTO
    {
        public int id_preaval { get; set; }
        public string revisionprecontractual { get; set; }
        public int? id_revsigep { get; set; }
        public int? id_asuntosdisciplinarios { get; set; }
        public int? id_estadopreaval { get; set; }
        public DecVie_RevSigep Objrevsigep { get; set; }
        public DecVie_AsuntosDisciplinarios Objasuntosdisciplinarios { get; set; }
        public DecVie_EstadoPreAval Objestadopreaval { get; set; }

        [NotMapped]
        public string NombreRevSigep
        {
            get
            {
                return (Objrevsigep == null) ? "" : Objrevsigep.nmrevsigep;
            }
        }

        [NotMapped]
        public string NombreAsuntoDisciplinario
        {
            get
            {
                return (Objasuntosdisciplinarios == null) ? "" : Objasuntosdisciplinarios.nmasuntosdisciplinarios;
            }
        }

        [NotMapped]
        public string NombreEstadoPreaval
        {
            get
            {
                return (Objestadopreaval == null) ? "" : Objestadopreaval.nmestadopreaval;
            }
        }

    }
}