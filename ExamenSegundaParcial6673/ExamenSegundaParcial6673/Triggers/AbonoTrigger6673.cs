using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ExamenSegundaParcial6673.Triggers
{
    public class AbonoTrigger6673 : TriggerAction<Entry>
    {
        protected override void Invoke(Entry sender)
        {
            var entry = sender as Entry;
            var flag = int.TryParse(entry.Text, out int cantidad);
            entry.BackgroundColor = ((!flag) || cantidad > 0) ? Color.Red : Color.Gray;
        }
    }
}
