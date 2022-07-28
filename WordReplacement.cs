namespace TextReplacer
{
    public class WordReplacement
    {
        public WordReplacement(string maleReplacement, string femaleReplacement)
        {
            MaleReplacement = maleReplacement;
            FemaleReplacement = femaleReplacement;
        }

        public string MaleReplacement { get; }
        public string FemaleReplacement { get; }

        public string GetReplacement(Gender gender)
        {
            return gender switch
            {
                Gender.Male => MaleReplacement,
                Gender.Female => FemaleReplacement,
                _ => throw new NotImplementedException()
            };
        }
    }
}
