function isPalindrome(input) {
    return input == input.split('').reverse().join('');
}