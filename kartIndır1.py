import os
import requests

# İndirilecek PNG dosyalarının URL'leri
base_url = "https://raw.githubusercontent.com/hayeah/playing-cards-assets/master/png/"

# İndirilecek kartların isimleri
cards = [
    "2_of_clubs", "3_of_clubs", "4_of_clubs", "5_of_clubs", "6_of_clubs", "7_of_clubs", "8_of_clubs", "9_of_clubs", "10_of_clubs", "jack_of_clubs", "queen_of_clubs", "king_of_clubs", "ace_of_clubs",
    "2_of_diamonds", "3_of_diamonds", "4_of_diamonds", "5_of_diamonds", "6_of_diamonds", "7_of_diamonds", "8_of_diamonds", "9_of_diamonds", "10_of_diamonds", "jack_of_diamonds", "queen_of_diamonds", "king_of_diamonds", "ace_of_diamonds",
    "2_of_hearts", "3_of_hearts", "4_of_hearts", "5_of_hearts", "6_of_hearts", "7_of_hearts", "8_of_hearts", "9_of_hearts", "10_of_hearts", "jack_of_hearts", "queen_of_hearts", "king_of_hearts", "ace_of_hearts",
    "2_of_spades", "3_of_spades", "4_of_spades", "5_of_spades", "6_of_spades", "7_of_spades", "8_of_spades", "9_of_spades", "10_of_spades", "jack_of_spades", "queen_of_spades", "king_of_spades", "ace_of_spades"
]

# Kartları kaydetmek için bir dizin oluşturun
output_dir = "playing_cards"
if not os.path.exists(output_dir):
    os.makedirs(output_dir)

# Kartları indirin ve kaydedin
for card in cards:
    png_url = f"{base_url}{card}.png"
    response = requests.get(png_url)
    if response.status_code == 200:
        with open(os.path.join(output_dir, f"{card}.png"), 'wb') as f:
            f.write(response.content)
        print(f"Saved {card}.png")
    else:
        print(f"Failed to download {card}.png")

print("All cards have been downloaded and saved.")
