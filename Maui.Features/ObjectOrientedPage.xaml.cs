namespace Maui.Features;
public partial class ObjectOrientedPage : ContentPage
{
    public ObjectOrientedPage()
    {
       
        InitializeComponent();

        Transaction DebitTransaction = new Transaction(200.00m, DateTime.Now, "فاتورة شراء اغراض", "Debit");
        DebitTransaction.CompleteTransaction();
        string DebitTransactionInfo = DebitTransaction.TransactionDetails();
        DebitTransaction.Amount = 200m;


        VoucherTransaction voucherTransaction = new VoucherTransaction(10.00m, DateTime.Now, "شراء كرت مدار 10 دينار", "Credit");
        string voucherTransactionInfo = voucherTransaction.VoucherDetails();

        BookingTransaction BookingTransaction = new BookingTransaction(450.00m, DateTime.Now, "حجز فندق المهاري 5 نجوم", "Credit", "المهاري", 3);
        var BookingTransactionInfo = BookingTransaction.TransactionDetails();

        Transaction[] allTransactions = new Transaction[]
        {
            DebitTransaction,
            voucherTransaction,
            BookingTransaction,
        };
    }
}
//فوائد ال OOP :
//تنظيم الكود: يوفر الكلاس  هيكلية واضحة ومنظمة لتخزين وإدارة المعاملات المالية.
//التغليف: استخدام الخصائص للتحكم في الوصول إلى الحقول والتحقق من صحة القيم.
//إعادة الاستخدام: يمكن إنشاء كائنات متعددة من الكلاس بنفس الهيكلية والقواعد.
//الصيانة: الكود أكثر قابلية للصيانة والتعديل بفضل التغليف وتنظيم الكود بشكل جيد.

public class Transaction
{
    // الحقول الخاصة (Fields)
    public static int totalTransactions = 0;   // حقل ثابت لتتبع عدد المعاملات
    public int transactionId;         // حقل غير ثابت
    private decimal amount ;
    private DateTime date;
    private string? description;
    private string? transactionType;
    private string? status;


    //===================================================================================================
    // البناء (Constructor)
    public Transaction(decimal amount, DateTime date, string description, string transactionType)
    {
        totalTransactions += 1;
        this.TransactionId = totalTransactions;
        this.Amount = amount;
        this.Date = date;
        this.Description = description;
        this.TransactionType = transactionType;
        this.Status = "Pending";
    }

    //===================================================================================================
    // الخصائص (Properties)
    //الخصائص توفر طريقة للتحكم في الوصول إلى الحقول، مما يسمح بالحصول على قيمة الحقل أو تعيينها
    //يمكن أن تكون خصائص تلقائية (auto-properties) أو خصائص مع منطق مخصص.

    // خاصية ثابتة لقراءة العدد الإجمالي للمعاملات

    public static int TotalTransactions
    {
        get { return totalTransactions; }
    }
    public int TransactionId
    {
        get { return transactionId; }
        private set { transactionId = value; }
    }
    public decimal Amount
    {
        get { return amount; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Amount cannot be negative.");
            amount = value;
        }
    }
    public DateTime Date
    {
        get { return date; }
        set
        {
            if (value > DateTime.Now)
                date = DateTime.Now;
            date = value;
        }
    }
    public string Description
    {
        get { return description; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Description cannot be empty.");
            description = value;
        }
    }
    public string TransactionType
    {
        get { return transactionType; }
        set
        {
            if (value != "Credit" && value != "Debit")
                throw new ArgumentException("Transaction type must be either 'Credit' or 'Debit'.");
            transactionType = value;
        }
    }
    public string Status
    {
        get { return status; }
        private set
        {
            if (value != "Pending" && value != "Completed" && value != "Canceled")
                throw new ArgumentException("Invalid status value.");
            status = value;
        }
    }

    //===================================================================================================
    //الدوال والسلوك (Methods) :
    //الطرق هي الدوال التي تعرّف داخل الكلاس وتحدد سلوك الكائن.
    public void CompleteTransaction()
    {
        if (Status == "Pending")
        {
            Status = "Completed";
            Console.WriteLine("Transaction completed successfully.");
        }
        else
        {
            Console.WriteLine("Transaction cannot be completed. Current status: " + Status);
        }
    }
    public void CancelTransaction()
    {
        if (Status == "Pending")
        {
            Status = "Canceled";
            Console.WriteLine("Transaction canceled successfully.");
        }
        else
        {
            Console.WriteLine("Transaction cannot be canceled. Current status: " + Status);
        }
    }
    public virtual string TransactionDetails()
    {
        return $"Transaction Details: \r\n ID: {TransactionId}\r\n Amount: {Amount}\r\n Date: {Date}\r\n Description: {Description}\r\n Status: {Status}";
    }
}
public class VoucherTransaction : Transaction
{
    public VoucherTransaction(decimal amount, DateTime date, string description, string transactionType)
                             : base(amount, date, description, transactionType)
    {
    }

    private string? pinCode;
    private string? expiryDate;
    //add more fileds as you want ...

    //Add Property & Methods to handle fields behaviour as the transaction Example ...
    public string VoucherDetails()
    {
        return $"Transaction Details: \r\n ID: {TransactionId}\r\n Amount: {Amount}\r\n Date: {Date}\r\n Description: {Description}\r\n Status: {Status}\r\n Pin Code: {Guid.NewGuid().ToString()}\r\n Expiry Date: {DateTime.Now.AddDays(400)}";
    }
}
public class BookingTransaction : Transaction
{
    public BookingTransaction(decimal amount, DateTime date, string description, string transactionType, string hotileName, int adultNumber = 1)
                             : base(amount, date, description, transactionType)
    {
        this.hotileName = hotileName;
        this.adultNumber = adultNumber;
        //........
    }

    private string? hotileName;
    private int adultNumber;
    private string? roomNumber;
    private bool hasWifi;
    private bool hasParking;
    private bool hasBrackfast;

    public override string TransactionDetails()
    {
        return $"Booking Transaction Details: \r\n ID: {TransactionId}\r\n Amount: {Amount}\r\n Date: {Date}\r\n Description: {Description}\r\n Status: {Status}";
    }
}


public class Kremed
{
    public static int totalSortNumber = 0;
    public int id = 0;
}