﻿using COMP123_S2019_FinalTestB.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMP123_S2019_FinalTestB.Objects;

/*
 * STUDENT NAME: Jarod Lavine
 * STUDENT ID: 301037634
 * DESCRIPTION: This is the driver class for the application
 */

namespace COMP123_S2019_FinalTestB
{
    static class Program
    {
        
        public static CharacterGeneratorForm characterForm;
        public static Character character;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            characterForm = new CharacterGeneratorForm();
            character = new Character();

            Application.Run(characterForm);
        }
    }
}
