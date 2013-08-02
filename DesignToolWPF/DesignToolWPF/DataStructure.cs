using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DesignToolWPF
{
    class DataStructure
    {
        public ResearchQuestion researchQuestion { set; get; }
        Arrangement arrangement;
        List<IndependentVariable> independentVariables;
        List<DependentVariable> dependentVariables;

        public DataStructure()
        {
            researchQuestion = new ResearchQuestion();
            arrangement = new Arrangement();
            independentVariables = new List<IndependentVariable>();
            dependentVariables = new List<DependentVariable>();
        }

        // Construct from an existing xml file.
        public DataStructure(String path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            // Initiate research question.
            XmlNode researchQuestionNode = doc.SelectSingleNode("/design_guide/research_question");
            researchQuestion = new ResearchQuestion();
            researchQuestion.experimentTitle = researchQuestionNode.SelectSingleNode("experiment_title").InnerText;
            researchQuestion.experimentDescription = researchQuestionNode.SelectSingleNode("experiment_description").InnerText;
            researchQuestion.experimentConductor = researchQuestionNode.SelectSingleNode("experiment_conductor").InnerText;
            researchQuestion.hypothesis.mainSolution = researchQuestionNode.SelectSingleNode("/hypothesis/main_solution").InnerText;
            // Initiate compare solutions.
            XmlNode compareSolutionsNode = researchQuestionNode.SelectSingleNode("/hypothesis/compare_solutions");
            XmlNodeList compareSolutionsNodeList = compareSolutionsNode.SelectNodes("compare_solution");
            foreach (XmlNode node in compareSolutionsNodeList)
            {
                ResearchQuestion.Hypothesis.CompareSolution compareSolution = new ResearchQuestion.Hypothesis.CompareSolution();
                compareSolution.id = Int32.Parse(node.SelectSingleNode("id").InnerText);
                compareSolution.name = node.SelectSingleNode("name").InnerText;
                researchQuestion.hypothesis.compareSolutions.Add(compareSolution);
            }
            // Initiate tasks.
            XmlNode tasksNode = researchQuestionNode.SelectSingleNode("/hypothesis/tasks");
            XmlNodeList tasksNodeList = tasksNode.SelectNodes("task");
            foreach (XmlNode node in tasksNodeList)
            {
                ResearchQuestion.Hypothesis.Task task = new ResearchQuestion.Hypothesis.Task();
                task.id = Int32.Parse(node.SelectSingleNode("id").InnerText);
                task.name = node.SelectSingleNode("name").InnerText;
                researchQuestion.hypothesis.tasks.Add(task);
            }
            // Initiate context.
            researchQuestion.hypothesis.context = researchQuestionNode.SelectSingleNode("/hypothesis/context").InnerText;
            // Initiate measures.
            XmlNode measuresNode = researchQuestionNode.SelectSingleNode("/hypothesis/measures");
            XmlNodeList measuresNodeList = measuresNode.SelectNodes("measure");
            foreach (XmlNode node in measuresNodeList)
            {
                ResearchQuestion.Hypothesis.Measure measure = new ResearchQuestion.Hypothesis.Measure();
                measure.id = Int32.Parse(node.SelectSingleNode("id").InnerText);
                measure.name = node.SelectSingleNode("name").InnerText;
                researchQuestion.hypothesis.measures.Add(measure);
            }
            // Initiate target population.
            researchQuestion.hypothesis.targetPopulation = researchQuestionNode.SelectSingleNode("/hypothesis/target_population").InnerText;
            // End of initiating research question.

            // Initiate variables.
            XmlNode variablesNode = doc.SelectSingleNode("/design_guide/variables");
            XmlNodeList ivNodeList = variablesNode.SelectNodes("independent_variable");
            foreach (XmlNode ivNode in ivNodeList)
            {
                IndependentVariable iv = new IndependentVariable();
                iv.name = ivNode.SelectSingleNode("name").InnerText;
                iv.type = (IndependentVariable.IVTYPE)Enum.Parse(typeof(IndependentVariable.IVTYPE), ivNode.SelectSingleNode("type").InnerText, true);
                XmlNode levelsNode = ivNode.SelectSingleNode("levels");
                XmlNodeList levelsNodeList = levelsNode.SelectNodes("level");
                foreach (XmlNode node in levelsNodeList)
                {
                    IndependentVariable.Level level = new IndependentVariable.Level();
                    level.id = Int32.Parse(node.SelectSingleNode("id").InnerText);
                    level.value = node.SelectSingleNode("value").InnerText;
                    iv.levels.Add(level);
                }
                iv.counterBalance = (IndependentVariable.COUNTERBALANCE)Enum.Parse(typeof(IndependentVariable.COUNTERBALANCE), ivNode.SelectSingleNode("counter_balance").InnerText, true);
                independentVariables.Add(iv);
            }
            XmlNodeList dvNodeList = variablesNode.SelectNodes("dependent_variable");
            foreach (XmlNode node in dvNodeList)
            {
                DependentVariable dv = new DependentVariable();
                dv.name = node.SelectSingleNode("name").InnerText;
                dependentVariables.Add(dv);
            }
            // End of initiating variables.

            // Initiate arrangement.
            XmlNode arrangementNode = doc.SelectSingleNode("/design_guide/arrangement");
            arrangement = new Arrangement();
            arrangement.minNum = Int32.Parse(arrangementNode.SelectSingleNode("min_number").InnerText);
            arrangement.actualNum = Int32.Parse(arrangementNode.SelectSingleNode("actual_number").InnerText);
            arrangement.feePerParticipant = Int32.Parse(arrangementNode.SelectSingleNode("fee_per_participant").InnerText);
            arrangement.trial = Int32.Parse(arrangementNode.SelectSingleNode("trial").InnerText);
            arrangement.timePerTrial = Int32.Parse(arrangementNode.SelectSingleNode("time_per_trial").InnerText);
            arrangement.block = Int32.Parse(arrangementNode.SelectSingleNode("block").InnerText);
            XmlNode participantsNode = arrangementNode.SelectSingleNode("participants");
            XmlNodeList participantsNodeList = participantsNode.SelectNodes("participant");
            foreach (XmlNode node in participantsNodeList)
            {
                Arrangement.Participant participant = new Arrangement.Participant();
                participant.id = Int32.Parse(node.SelectSingleNode("id").InnerText);
                participant.individualArrangement = node.SelectSingleNode("individual_arrangement").InnerText;
                arrangement.participants.Add(participant);
            }
            // End of Initiating arrangement.
        }

        // Store to an xml file.
        public bool WriteToXml(String path)
        {
            using (XmlWriter writer = XmlWriter.Create(path))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("design_guide");

                // Write research question.
                writer.WriteStartElement("research_question");
                writer.WriteElementString("experiment_title", researchQuestion.experimentTitle);
                writer.WriteElementString("experiment_description", researchQuestion.experimentDescription);
                writer.WriteElementString("experiment_conductor", researchQuestion.experimentConductor);

                writer.WriteStartElement("hypothesis");
                writer.WriteElementString("main_solution", researchQuestion.hypothesis.mainSolution);
                writer.WriteStartElement("compare_solutions");
                foreach (ResearchQuestion.Hypothesis.CompareSolution compareSolution in researchQuestion.hypothesis.compareSolutions)
                {
                    writer.WriteStartElement("compare_solution");
                    writer.WriteElementString("id", compareSolution.id.ToString());
                    writer.WriteElementString("name", compareSolution.name);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteStartElement("tasks");
                foreach (ResearchQuestion.Hypothesis.Task task in researchQuestion.hypothesis.tasks)
                {
                    writer.WriteStartElement("task");
                    writer.WriteElementString("id", task.id.ToString());
                    writer.WriteElementString("name", task.name);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteElementString("context", researchQuestion.hypothesis.context);
                writer.WriteStartElement("measures");
                foreach (ResearchQuestion.Hypothesis.Measure measure in researchQuestion.hypothesis.measures)
                {
                    writer.WriteStartElement("measure");
                    writer.WriteElementString("id", measure.id.ToString());
                    writer.WriteElementString("name", measure.name);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteElementString("target_population", researchQuestion.hypothesis.targetPopulation);
                writer.WriteEndElement();

                // End of research question
                writer.WriteEndElement();
                

                // Write variables.
                writer.WriteStartElement("variables");
                
                // Write independent variables.
                foreach (IndependentVariable independentVariable in independentVariables)
                {
                    writer.WriteStartElement("independent_variable");
                    writer.WriteElementString("name", independentVariable.name);
                    writer.WriteElementString("type", independentVariable.type.ToString());
                    writer.WriteStartElement("levels");
                    foreach (IndependentVariable.Level level in independentVariable.levels)
                    {
                        writer.WriteStartElement("level");
                        writer.WriteElementString("id", level.id.ToString());
                        writer.WriteElementString("value", level.value);
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    writer.WriteElementString("counter_balance", independentVariable.counterBalance.ToString());
                    writer.WriteEndElement();
                }
                // End of independent variables.

                // Write dependent variables.
                foreach (DependentVariable dependentVariable in dependentVariables)
                {
                    writer.WriteStartElement("dependent_variable");
                    writer.WriteElementString("name", dependentVariable.name);
                    writer.WriteEndElement();
                }
                // End of dependent variables.

                // Write control variables. Not implemented!
                // End of control variables.

                // Write random variables. Not implemented!
                // End of random variables.

                // End of variables.
                writer.WriteEndElement();


                // Write arrangement.
                writer.WriteStartElement("arrangement");
                writer.WriteElementString("min_number", arrangement.minNum.ToString());
                writer.WriteElementString("actual_number", arrangement.actualNum.ToString());
                writer.WriteElementString("fee_per_participant", arrangement.feePerParticipant.ToString());
                writer.WriteElementString("trial", arrangement.trial.ToString());
                writer.WriteElementString("time_per_trial", arrangement.timePerTrial.ToString());
                writer.WriteElementString("block", arrangement.block.ToString());
                writer.WriteStartElement("participants");
                foreach (Arrangement.Participant participant in arrangement.participants)
                {
                    writer.WriteStartElement("participant");
                    writer.WriteElementString("id", participant.id.ToString());
                    writer.WriteElementString("individual_arrangment", participant.individualArrangement);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                // End of arrangement.
                writer.WriteEndElement();


                // End of design_guide and document.
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            return true;
        }
    }

    class ResearchQuestion
    {
        public string experimentTitle { get; set; }
        public string experimentDescription { get; set; }
        public string experimentConductor { get; set; }
        public Hypothesis hypothesis;

        public ResearchQuestion()
        {
            hypothesis = new Hypothesis();
        }

        public class Hypothesis
        {
            public string mainSolution;
            public List<CompareSolution> compareSolutions;
            public List<Task> tasks;
            public string context;
            public List<Measure> measures;
            public string targetPopulation;

            public Hypothesis()
            {
                compareSolutions = new List<CompareSolution>();
                tasks = new List<Task>();
                measures = new List<Measure>();
            }

            public class CompareSolution
            {
                public int id;
                public string name;
                public CompareSolution()
                { 
                }
                public CompareSolution(int id, string name)
                {
                    this.id = id;
                    this.name = name;
                }
            }

            public class Task
            {
                public int id;
                public string name;
                public Task()
                { 
                }
                public Task(int id, string name)
                {
                    this.id = id;
                    this.name = name;
                }
            }

            public class Measure
            {
                public int id;
                public string name;
                public Measure()
                { 
                }
                public Measure(int id, string name)
                {
                    this.id = id;
                    this.name = name;
                }
            }
        }
    }

    class IndependentVariable
    {
        public string name { get; set; }
        public IVTYPE type;
        public COUNTERBALANCE counterBalance;
        public List<Level> levels;

        public IndependentVariable()
        {
            levels = new List<Level>();
        }

        public enum IVTYPE { Primary, Secondary };

        public enum COUNTERBALANCE { None, LatinSquare, Full };
        
        public class Level
        {
            public int id;
            public string value;
        }
    }

    class DependentVariable
    {
        public string name { get; set; }
    }

    class ControlVariable
    {
    }

    class RandomVariable
    {
    }

    class Arrangement
    {
        public int minNum { get; set; }
        public int actualNum { get; set; }
        public int feePerParticipant { get; set; }
        public int trial { get; set; }
        public int timePerTrial { get; set; }
        public int block { get; set; }
        public List<Participant> participants;

        public Arrangement()
        {
            participants = new List<Participant>();
        }

        public class Participant
        {
            public int id;
            public string individualArrangement;
        }
    }
}
