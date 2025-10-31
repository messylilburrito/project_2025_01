public class MyNewClass {
    private String name;
    private int value;
    
    // Конструктор
    public MyNewClass(String name, int value) {
        this.name = name;
        this.value = value;
    }
    
    // Геттеры и сеттеры
    public String getName() {
        return name;
    }
    
    public void setName(String name) {
        this.name = name;
    }
    
    public int getValue() {
        return value;
    }
    
    public void setValue(int value) {
        this.value = value;
    }
    
    // Метод для вывода информации
    public void displayInfo() {
        System.out.println("Name: " + name + ", Value: " + value);
    }
    
    // Главный метод для тестирования
    public static void main(String[] args) {
        MyNewClass obj = new MyNewClass("Test", 42);
        obj.displayInfo();
    }
}
