plain = "abcdefghijklmnopqrstuvwxyz"
cipher = "zyxwvutsrqponmlkjihgfedcba"

def encode(plain_text):
    encoded = [l if l.isdigit() else cipher[plain.find(l)]
               for l in plain_text.lower() if l.isalnum()]

    ciphertext = ""
    for index, l in enumerate(encoded):
        ciphertext += l
        index += 1
        if index % 5 == 0:
            ciphertext += ' '

    return ciphertext.rstrip()


def decode(ciphered_text):
    return "".join([l if l.isdigit() else plain[cipher.find(l)] for l in ciphered_text if l.isalnum()])