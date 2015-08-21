FooFileIterator iter = new FooFileIterator(fileLocation, log);
LoadManager manager = new FooFileLoadManager(iter);
SubFooObject obj = 
(SubFooObject)ReflectiveObjectLoader.initializeInstance(SubFooObject.class, manager,log);
public class MethodForInt extends MethodCode {
        private final static MethodParameter param = new MethodParameter(SimpleFileIterator.class, "parser");
        public MethodForInt(Class type, CodeBuilder builder){
               super(type, builder);
        }
        public MethodParameter[] getInputParameters(){
               return new MethodParameter[]{
                      param
               };
        }
        public MethodParameter[] getInstanceParameters(){
              return getInputParameters();
        }
        protected String getImplBody(CodeBuilder builder){
              return "return " + param.getName() + ".nextInt();\n";
        }
}
/** Generated Load method for int**/
final public static int loadint(com.thoughtworks.rettig.util.SimpleFileIterator parser){
return parser.nextInt();
}
<target name = "GenerateLoad">
<java classname = "com.thoughtworks.rettig.loadGenerator.LoadWriter"
dir = "."
fork = "yes">
<arg value = "com.thoughtworks.rettig.example.generated"/>
<arg value = "com.thoughtworks.rettig.example.PurchaseOrder"/>
         </java>
</target>
fileIterator.nextString();