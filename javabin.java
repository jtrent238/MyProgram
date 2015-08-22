AST ast = AST.newAST(AST.JLS3);
CompilationUnit cu = ast.newCompilationUnit();

PackageDeclaration p1 = ast.newPackageDeclaration();
p1.setName(ast.newSimpleName("foo"));
cu.setPackage(p1);

ImportDeclaration id = ast.newImportDeclaration();
id.setName(ast.newName(new String[] { "java", "util", "Set" }));
cu.imports().add(id);

TypeDeclaration td = ast.newTypeDeclaration();
td.setName(ast.newSimpleName("Foo"));
TypeParameter tp = ast.newTypeParameter();
tp.setName(ast.newSimpleName("X"));
td.typeParameters().add(tp);
cu.types().add(td);

MethodDeclaration md = ast.newMethodDeclaration();
td.bodyDeclarations().add(md);

Block block = ast.newBlock();
md.setBody(block);

MethodInvocation mi = ast.newMethodInvocation();
mi.setName(ast.newSimpleName("x"));

ExpressionStatement e = ast.newExpressionStatement(mi);
block.statements().add(e);

System.out.println(cu);