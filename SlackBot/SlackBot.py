import requests
import json

def getWordOfDay():
    url = "https://www.vocabulary.com/dictionary/randomword"
    response = requests.get(url)
    print("Vocabulary.com: Status code", response.status_code)
    print("Vocabulary.com: JSON response ", response.text)
    word = response.url.split('/')[-1]
    # meaning = TODO
    # Web scrapper functionality here
    # Add meaning and make the response a tuple
    return word, 'TBD'
    

def sendWordOfDayToSlackChannel(word='N/A', meaning='TBD'):
    url = "https://hooks.slack.com/services/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" # TODO: Replace {0} and {1} with proper secrets
    text =  f"Today's word is: {word}. Meaning: {meaning}."
    data = { "text": text }
    response = requests.post(url, json=data)
    print("Slack hook: Status Code", response.status_code)
    print("Slack hook: JSON Response ", response.text)


if __name__ == '__main__':
    word, meaning = getWordOfDay()
    sendWordOfDayToSlackChannel(word, meaning)