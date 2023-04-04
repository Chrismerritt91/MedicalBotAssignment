class Patient
{

    private string name;
    private int age;
    private string gender;
    private string medicalHistory;
    private string symptomCode;
    private string prescription;

    public string GetName()
    {
        return name;
    }

    public void SetName(string name, out string errorMessage)
    {
        if (name == null || name == "" || name.Length <= 2)
        {
            errorMessage = "false";
        }
        else
        {
            errorMessage = "true";
            this.name = name;
        }
    }

    public int GetAge()
    {
        return age;
    }

    public void SetAge(int age, out string errorMessage)
    {
        if (age < 0 || age > 100)
        {
            errorMessage = "false";
        }
        else
        {
            errorMessage = "true";
            this.age = age;
        }
    }

    public string GetGender()
    {
        return this.gender;
    }

    public void SetGender(string gender, out string errorMessage)
    {
        if (gender != "male" || gender != "female" || gender != "other")
        {
            errorMessage = "false";
        }
        else
        {
            errorMessage = "true";
            this.gender = gender;
        }
    }

    public string GetMedicalHistory()
    {
        return this.medicalHistory;
    }

    public void SetMedicalHistory(string condition)
    {
        this.medicalHistory = condition;
    }

    public string GetSymptomCode()
    {
        return this.symptomCode;
    }

    public void SetSymptomCode(string symptom)
    {
        this.symptomCode = symptom;
    }

    public string GetPrescription()
    {
        return this.prescription;
    }

    public void SetPrescription(string prescription)
    {
        this.prescription = prescription;
    }
}


class MedicalBot
{

    public const string BotName = "Bob";


    public void PrescribeMedication(Patient patient)
    {

        string symptom = patient.GetSymptomCode();
        string medicalHistory = patient.GetMedicalHistory();

        //headache s1, skin rashes s2, dizziness s3
        if (symptom == "s1")
        {
            patient.SetPrescription("ibuprofen " + GetDosage("ibuprofen"));
        }
        else if (symptom == "s2")
        {
            patient.SetPrescription("diphenhydramine " + GetDosage("diphenhydramine"));
        }
        else if (symptom == "s3")
        {
            if (medicalHistory == "diabetes")
            {
                patient.SetPrescription("metformin " + GetDosage("metformin"));
            }
            else
            {
                patient.SetPrescription("dimenhydrinate ");
            }
        }

        string GetDosage(string medicineName)
        {

            int patientAge = patient.GetAge();

            if (medicineName == "ibuprofen")
            {
                if (patientAge < 18)
                {
                    return "400 mg";
                }
                else
                {
                    return "800 mg";
                }
            }
            else if (medicineName == "diphenhydramine")
            {
                if (patientAge < 18)
                {
                    return "50 mg";
                }
                else
                {
                    return"300 mg";
                }

            }
            else if (medicineName == "metformin")
            {
                return "500 mg";
            }
            else {
                return "Dosage Given By Doctor";
            }
        }
    }

    public static string GetBotName()
    {

        return BotName;
    }

}

class Program {

static void Main() {

        Patient p = new Patient();
        MedicalBot m = new MedicalBot();

        string error;

        Console.WriteLine("Hi, I'm " + MedicalBot.GetBotName() + ". I'm here to help you in your medication");
        Console.WriteLine("\nEnter your (Patient) details:");
        Console.WriteLine("\nEnter Patient Name:");
        string name = System.Console.ReadLine();
        p.SetName(name, out error);
        Console.WriteLine("\nEnter Patient Age:");
        int age = int.Parse(System.Console.ReadLine());
        p.SetAge(age, out error);
        Console.WriteLine("\nEnter Patient Gender:(male,female,other)");
        string gender = System.Console.ReadLine().ToLower();
        p.SetGender(gender, out error);
        Console.WriteLine("\nEnter Medical History. Eg: Diabetes. Press Enter for None:");
        string history = System.Console.ReadLine().ToLower();
        p.SetMedicalHistory(history);
        Console.WriteLine("\nWelcome " + p.GetName() + ", " + p.GetAge());
        Console.WriteLine("\nWhich of the following symptoms do you have:");
        Console.WriteLine("\nS1. Headache");
        Console.WriteLine("\nS2. Skin Rashes");
        Console.WriteLine("\nS3. Dizziness");
        Console.WriteLine("\nEnter symptom code from above list (S1,S2,S3):");
        string symptom = System.Console.ReadLine().ToLower();
        p.SetSymptomCode(symptom);
        Console.WriteLine("\nYour prescription based on your age, symptoms, and medical history:");
        m.PrescribeMedication(p);
        Console.WriteLine("\n" + p.GetPrescription());
        Console.WriteLine("\nThank you for coming");
        System.Console.ReadKey();


    }

}