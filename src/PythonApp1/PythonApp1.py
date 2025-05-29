# Напиши в консоль "Учебное приложение"
print("Учебное приложение")

def larger(num1, num2):
    """
    num1 и num2 - два числа
    Верни большее из двух чисел
    """
    if num1 > num2:
        return num1
    else:
        return num2

# Вызови функцию larger со значениями 2 и 3
# Сохрани результат в переменной result
# Затем выведи результат
result = larger(2, 3)
print(result)

# Создай список чисел
numbers = [1, 2, 3, 4, 5]

# Найди сумму всех чисел в списке
sum_of_numbers = sum(numbers)

# Выведи сумму
print(sum_of_numbers)

