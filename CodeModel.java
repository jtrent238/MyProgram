JCodeModel cm = new JCodeModel();
JDefinedClass dc = cm._class("foo.Bar");
JMethod m = dc.method(0, int.class, "foo");
m.body()._return(JExpr.lit(5));

File file = new File("./target/classes");
file.mkdirs();
cm.build(file);