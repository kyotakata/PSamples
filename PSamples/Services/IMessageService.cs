using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PSamples.Services
{
    /// <summary>
    /// IMessageService
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// ShowDialog
        /// </summary>
        /// <param name="message"></param>
        void ShowDialog(string message);

        /// <summary>
        /// Question
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        MessageBoxResult Question(string message);
    }
}
