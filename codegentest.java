elp you get started. (See Resources.)

package codegen.samples;
import com.sun.javadoc.*;
import java.text.*;
public static boolean start(RootDoc root) {
  //iterate over all classes.
  ClassDoc[] classes = root.classes();
  for (int i=0; i< classes.length; i++) {
    //iterate over all methods and print their names.
    MethodDoc[] methods = classes[i].methods();
    out("Methods");
    out("-------");
    for (int j=0; j<methods.length; j++) {
      out("Method: name = " + methods[j].name());
    }
    out("Fields");
    out("------");
    //iterate over all fields, printing name, comment text, and type.
    FieldDoc[] fields = classes[i].fields();
    for (int j=0; j<fields.length; j++) {
      Object[] field_info = {fields[j].name(), fields[j].commentText(),
                    fields[j].type()};
      out(FIELDINFO.format(field_info));
      //iterate over all field tags and print their values.
      Tag[] tags = fields[j].tags();
      for (int k=0; k<tags.length; k++) {
     out("\tField Tag Name= " + tags[k].name());
     out("\tField Tag Value = " + tags[k].text());
      }
    }
  }
  //No error processing done, simply return true.
  return true;
}
private static void out(String msg) {
  System.out.println(msg);
}
private static MessageFormat METHODINFO =
  new MessageFormat("Method: return type {0}, name = {1};");
private static MessageFormat FIELDINFO =
  new MessageFormat("Field: name = {0}, comment = {1}, type = {2};");
}
Loading source file SimpleOrder.java...
Constructing Javadoc information...
Methods
-------
Method: name = getSymbol
Method: name = getQuantity
Fields
------
Field: name = Symbol, comment = A valid stock symbol., type = 
java.lang.String;
      Field Tag Name= @see
      Field Tag Value = A big book of valid symbols for more information.
Field: name = Quantity, comment = The total order volume., type = int;
      Field Tag Name= @mytag
      Field Tag Value = My custom tag.
Field: name = OrderType, comment = , type = java.lang.String;
Field: name = Price, comment = , type = float;
Field: name = Duration, comment = , type = java.lang.String;
Field: name = AccountType, comment = , type = int;
Field: name = TransactionType, comment = , type = int;
public static boolean start(RootDoc root) {
  ClassDoc[] classes = root.classes();
  //Set up CodeMakers to run
  Maker simplemaker = new SimpleCodeMaker("Description Maker");
  //Iterate through all classes and execute the "make" method the Maker
  for (int i=0; i < classes.length; i++ ) {
    ClassDoc classdoc = classes[i];
    simplemaker.make(classdoc);
  }
  return true;
}