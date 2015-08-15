function Method1() {

    var elementById = document.getElementById('nameTextBox');
    var messsage = elementById.value;
    var upperCase = messsage.toString().toUpperCase();

    elementById.value = upperCase;
}