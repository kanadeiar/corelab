# Напиши в консоль "Учебное приложение"
print("Учебное приложение")

import random
import tkinter as tk
from tkinter import messagebox

def random_string(length):
    """
    length - это целое число/
    Верни строку заданной длины, где каждый символ - 
    это цифра от 0 до 9, без повтояющихся цифр
    """
    digits = list(range(10))
    random.shuffle(digits)
    return ''.join(map(str, digits[:length]))

def guess_result(guess, secret_code):
    """
    guess и secret_code - строки одинаковой длины.
    Верним список из двух значений: первое - количество индексов
    в guess, где символ в этом индексе совпадает с символом в secret_code,
    второе значение - количество индексов в guess,
    где символ в этом индексе существует в другом индексе в secret_code.

    >>> guess_result('3821', '1862')
    [1, 2]
    >>> guess_result('1234', '4321')
    [0, 4]
    """
    correct_digits = sum(1 for i in range(len(guess)) if guess[i] == secret_code[i])
    common_digits = sum(1 for i in range(len(guess)) if guess[i] in secret_code)
    return [correct_digits, common_digits]

def play(num_digits, num_guesses):
    secret_code = random_string(num_digits)
    attempts = 0

    def check_guess():
        nonlocal attempts
        guess = entry.get()
        if len(guess) == num_digits and guess.isdigit() and len(set(guess)) == num_digits:
            attempts += 1
            result = guess_result(guess, secret_code)
            messagebox.showinfo("Результат", f"Правильных: {result[0]}, Неправильных: {result[1]}")
            if result[0] == num_digits:
                messagebox.showinfo("Поздравляем!", "Вы угадали код!")
                root.quit()
            elif attempts >= num_guesses:
                messagebox.showinfo("Конец игры", f"К сожалению, вы не угадали код. Правильный код был: {secret_code}")
                root.quit()
        else:
            messagebox.showwarning("Ошибка", "Неправильная догадка. Пожалуйста, попробуйте снова.")

    root = tk.Tk()
    root.title("Игра в угадайку")

    label = tk.Label(root, text=f"Введите строку длиной {num_digits}:")
    label.pack()

    entry = tk.Entry(root)
    entry.pack()

    button = tk.Button(root, text="Проверить", command=check_guess)
    button.pack()

    root.mainloop()

play(4, 10)

    























