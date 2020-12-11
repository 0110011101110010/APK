/*
 * 
 * Kodo bendri užrašai pildomi tik į šitą failą.
 *
 * Ką rodys prisijungus naudotojui:
 * o Studentui meniu konteineryje paskaitas, ant paskaitos paspaudus pažymį (pagal sąlygą).
 * 
 * o Dėstytojui meniu konteineryje, jei turi daugiau nei vieną paskaitą, paskaitų sąrašą, jei tik vieną, paskaitos studentų sąrašą, o pagrindiniame konteineryje pasirinkto studento pažymį.
 * Juos gali redaguoti.
 * 
 * o Administratoriui meniu konteineryje funkcijas (kurti ir šalinti studentą, dėstytoją, dalykus, grupes; priskirti dėstytoją prie dalyko, studentus ir dalykus - prie grupės)
 * 
 * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
 * 
 * Darbo savaites tvarkarastis
 * 
 * Pr
 * o Pabaigti GradesRepository
 * o Panaudoti GradesRepository metodus Login'e
 * 
 * An
 * o Su visais naudotojais pabaigti atvaizdavima
 * o Realizuoti kiekvieno naudotojo funkcijas
 * 
 * Tr
 * o Pataisyti klaidas
 * 
 * Ket
 * o ATSISKAITYTI
 * 
 * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
 * 
 * SĄLYGA:
 * 
 * 0. Sukurti akademinę sistemą, kurioje būtų fiksuojami studentų vertinimai už dalykus. Programoje yra trys naudotojų lygiai: administratorius, dėstytojas, studentas.
 * 
 * 1. Administratorius gali valdyti (kurti ir šalinti) studentų grupes, dėstomus dalykus, dėstytojus ir studentus. Dėstytojus priskirti prie dėstomo dalyko, studentus ir dėstomą dalyką - prie grupės.
 * 
 * 2. Dėstytojas gali įvesti ir redaguoti pasirinkto studento dalyko pažymį.
 * 
 * 3. Studentas gali tik peržiūrėti savo pažymius.
 * 
 * 4. Papildomas reikalavimas: administratorius registruodamas studentą ar dėstytoją, automatiškai prisijungimo vardu priskiria vardą, o slaptažodžiu – pavardę.
 *
 * -----
 * 
 * 0. Sukurt 3 lenteles, po 1 kiekvienam naudotojui (administratorius, dėstytojas, studentas):
 * 
 * STUDENTAS (id, vardas, pavardė, username, password, grupėsId[allow_nulls=true]), DĖSTYTOJAS (id, vardas, pavardė, username, password, dalykoId[allow_nulls=true]), ADMINISTRATORIUS (id, vardas, pavardė, username, password)
 * ---
 * 1. Sukurt 2 lenteles (grupės, dalykai):
 * 
 * GRUPĖS (id, pavadinimas), DALYKAI (id, pavadinimas, grupėsId[allow_nulls=true]),
 * ---
 * 2. Sukurt 1 lentelę (vertinimai)
 * VERTINIMAS (pažymys, subjectId, studentId)
 * ---
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace akademine_sistema
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
