X clazz = Something.createClass("package name", "class name");
clazz.addSuperInterface("interface name");
clazz.addMethod("method name", returnType, argumentTypes, ...);

File targetDir = ...;
clazz.generate(targetDir);