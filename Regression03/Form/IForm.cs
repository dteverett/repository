namespace Form
{
    interface IForm
    {
        string Name { get; }
        string DateTime1 { get; }
        string DateTime1Replace { get; }
        string Unique1 { get; }
        string Unique1Replace { get; }
        string DateTime2 { get; }
        string DateTime2Replace { get; }
        string Unique2 { get; }
        string Unique2Replace { get; }
        char Key { get; }
        string File { get; set; }
        string ClaimID { get; }
        string ClaimIDReplace { get; }
    }
}
