using OldRuntasticProToGpx.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldRuntasticProToGpx
{
    public class ListBoxLogger : ILogger
    {
        private readonly ListBox _listBox;

        public ListBoxLogger(ListBox listBox)
        {
            _listBox = listBox;
        }


        public void LogSplitted(string message)
        {
            var splittedText = message.Split('\n');
            foreach (var line in splittedText)
            {
                Log(line);
            }
        }


        public void Log(string message)
        {
            if (_listBox.InvokeRequired)
            {
                _listBox.Invoke(new Action(() =>
                {
                    _listBox.Items.Add(message);
                    ForceRefresh();
                }));
            }
            else
            {
                _listBox.Items.Add(message);
                ForceRefresh();
            }
        }

        public void ClearAndLog(string message)
        {
            if (_listBox.InvokeRequired)
            {
                _listBox.Invoke(new Action(() => _listBox.Items.Clear())); 
            }
            else
            {
                _listBox.Items.Clear();
            }

            Log(message);
        }

        private void ForceRefresh()
        {
            _listBox.TopIndex = _listBox.Items.Count - 1; // Opcional: scroll al último elemento
            _listBox.Refresh(); // Fuerza la actualización visual
            Application.DoEvents(); // Procesa los mensajes pendientes de la cola
        }

    }
}
