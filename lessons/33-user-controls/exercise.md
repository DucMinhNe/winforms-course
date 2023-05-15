# Exercise — Lesson 33

1. Create `SearchBox : UserControl` with a `TextBox` + "Go" `Button` inside.
2. Expose `public string Query { get; set; }` that proxies the textbox text.
3. Declare `public event EventHandler Search;` and raise it on Go-click and on
   Enter (`OnSearch()`).
4. On a form, add two `SearchBox`es and subscribe to each one's `Search` with a
   different handler that reads `((SearchBox)sender).Query`.

**Done when:** the form interacts with the control only through `Query` and
`Search` — the inner textbox/button are private.
