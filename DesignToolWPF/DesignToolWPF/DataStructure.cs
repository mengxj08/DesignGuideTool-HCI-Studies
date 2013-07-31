using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignToolWPF
{
    class DataStructure
    {
        ResearchQuestion researchQuestion;
        Arrangement arrangement;
        List<IndependentVariable> independentVariables;
        List<DependentVariable> dependentVariables;

        public DataStructure()
        {
        }

        // Construct from an existing xml file.
        public DataStructure(String path)
        {
        }

        // Store to an xml file.
        public bool WriteToXml(String path)
        {
            return false;
        }
    }

    class ResearchQuestion
    {
        string experimentTitle;
        string experimentDescription;
        string experimentConductor;

        class Hypothesis
        {
            string mainSolution;
            List<CompareSolution> compareSolutions;
            List<Task> tasks;
            string context;
            List<Measure> measures;
            string targetPopulation;


            class CompareSolution
            {
                int id;
                string name;
            }

            class Task
            {
                int id;
                string name;
            }

            class Measure
            {
                int id;
                string name;
            }
        }
    }

    class IndependentVariable
    {
        string name;
        IVTYPE type;
        COUNTERBALANCE counterBalance;
        List<Level> levels;

        public enum IVTYPE { Primary, Secondary };

        public enum COUNTERBALANCE { None, LatinSquare, Full };
        
        class Level
        {
            int id;
            string value;
        }
    }

    class DependentVariable
    {
    }

    class ControlVariable
    {
    }

    class RandomVariable
    {
    }

    class Arrangement
    {
    }
}
