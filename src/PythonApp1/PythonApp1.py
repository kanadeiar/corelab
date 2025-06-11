# Напиши в консоль "Учебное приложение"
print("Учебное приложение")

import random

def random_string(length):
    """
    length - это целое число/
    Верни строку заданной длины, где каждый символ - 
    это цифра от 0 до 9, без повтояющихся цифр
    """
    digits = list(range(10))
    random.shuffle(digits)
    return ''.join(map(str, digits[:length]))

def get_guess(length):
    """
    length - это длинна строки

    Продолжай просить игрока ввести строку, в которой каждый символ является
    цифрой от 0 до 9, пока он не введет правильную догадку.
    Правильная догадка имеет заданную длинну
    и не содержит повторяющихся цифр.
    """
    while True:
        guess = input(f"Введите строку длиной {length}: ")
        if len(guess) == length and all(c.isdigit() for c in guess) and len(set(guess)) == length:
            return guess
        else:
            print("Неправильная догадка. Пожалуйста, попробуйте снова.")

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
    """
    Создай случайную строку с цифрами num_digits.
    у игрока есть догадки num_guesses, позволяющие угадать случайную строку.
    После каждой догадки игроку сообщается, сколько цифр в догадке
    находится на правильном месте и сколько цифр имеются,
    но находятся на неправильном месте.
    """
    secret_code = random_string(num_digits)
    for _ in range(num_guesses):
        guess = get_guess(num_digits)
        result = guess_result(guess, secret_code)
        print(f"Правильных: {result[0]} неправильных: {result[1]}")
        if result[0] == num_digits:
            print("Поздравляем! Вы угадали код!")
            return
    print(f"К сожалению, вы не угадали код. Правильный код был: {secret_code}")

play(4, 10)

    























