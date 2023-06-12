namespace HelloForms;

// Annotated view of a typical generated designer file.
partial class AnnotatedForm
{
    // 1) A container for components that need disposal (timers, tooltips...).
    private System.ComponentModel.IContainer components = null;

    // 2) One private field per control you placed.
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.TextBox textBox1;

    // 3) Generated disposal — chains to the components container.
    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    // 4) The heart of it: build + configure + wire + add, all generated.
    private void InitializeComponent()
    {
        this.button1 = new System.Windows.Forms.Button();
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.SuspendLayout();                       // batch layout

        // textBox1  (each Properties-window change = one line)
        this.textBox1.Location = new System.Drawing.Point(12, 12);
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(200, 23);

        // button1  (note the generated event wiring)
        this.button1.Location = new System.Drawing.Point(12, 45);
        this.button1.Name = "button1";
        this.button1.Text = "OK";
        this.button1.Click += new System.EventHandler(this.button1_Click);

        // AnnotatedForm
        this.ClientSize = new System.Drawing.Size(300, 120);
        this.Controls.Add(this.button1);
        this.Controls.Add(this.textBox1);
        this.Name = "AnnotatedForm";
        this.Text = "Designer demo";
        this.ResumeLayout(false);                   // relayout once
        this.PerformLayout();
    }
}
