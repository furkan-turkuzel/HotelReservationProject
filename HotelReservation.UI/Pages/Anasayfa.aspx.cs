using HotelReservation.DataAccess.Concreate.EntityFramework;
using HotelReservation.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelReservation.UI.Pages
{
    public partial class Anasayfa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HotelReservationDBContext db = new HotelReservationDBContext();
            ICollection<Users> üye = db.User.ToList();
        }
    }
}