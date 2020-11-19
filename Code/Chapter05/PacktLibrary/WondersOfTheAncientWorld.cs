namespace Packt.Shared
{
    [System.Flags]// so that when the value is returned it can automatically match with multiple values as a comma separeted string instead of returning an int value
    public enum WondersOfTheAncientWorld : byte
    {
        //Normally, an enum type uses an int variable internally, but since we don't need values that big, we can
        //reduce memory requirements by 75%, that is, 1 byte per value instead of 4 byes, by telling it yo use a byte variable
        None = 0b_0000_0000, // ie 0
        GreatPyramidOfGiza = 0b_0000_0001, // ie 1
        HangingGardensOfBabylon = 0b_0000_0010, // ie 2
        StatueOfZeusAtOlimpia = 0b_0000_0100, // ie 4
        TempleOfArtemisAtEphesus = 0b_0000_1000, // ie 8
        MausoleumAtHalicarnassus = 0b_0001_0000, // ie 16
        ColossusOfRhodes = 0b_0010_0000, // ie 32
        LighthouseOfAlezandria = 0b_0100_0000 // ie 64
    }
}