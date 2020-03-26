using System;
using System.Collections.Generic;
using System.Text;

namespace ATXBSAPP.ViewModels
{
    public class WebinarVewModel
    {
        public class ValueW
        {
            public string atx_name { get; set; }
            public string atx_descripcion { get; set; }
            public string atx_fechadeinicio { get; set; }
            public string atx_fechadefinalizacion { get; set; }
            public string atx_linkderegistro { get; set; }
            public string createdby { get; set; }
        }
        public class RootObject
        {
            public List<ValueW> value { get; set; }
        }
    }
}
