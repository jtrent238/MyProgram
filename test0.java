public String[] chkBox() {
    return chkBox;
}
String[] box = obj.chkBox();
box[0] = null;
return (String[])chkBox.clone();