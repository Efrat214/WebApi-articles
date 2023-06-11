# English Learning through Articles for Hebrew Speakers

This project is a Web API-based system designed to facilitate English language learning for Hebrew speakers through the use of articles. The system includes a test to determine the user's English proficiency level during registration. Users can then upload their own articles or select from an existing database. The system provides word recommendations related to the article's subject, scattered throughout the entire text and tailored to the user's proficiency level.

## Features

- User Registration:
  - During registration, users are required to complete an English proficiency test to determine their level.
  
- Article Upload/Selection:
  - Users can upload their own articles to the system or choose from a pre-existing database of articles.
  
- Article Classification and Word Recommendations:
  - The system classifies each article into a relevant subject using the Naive Bayes algorithm and  Using the Gensim Word2Vec model trained on the text8 dataset, the system provides word recommendations based on the article's subject and the user's proficiency level.
- Word Level Definition:
  - Word levels are determined using a dataset of word frequencies in English.
  
## Technologies Used

- Web API: The system is built as a Web API.
- React: The client-side was written in React (the full code is in the [React-Articles repository](https://github.com/your-username/React-Articles)).
- React: The client-side was written in React (the full code is in the [React-Articles repository]([https://github.com/your-username/React-Articles](https://github.com/Efrat214/React-articles))).
- Naive Bayes Algorithm: Used for article classification based on subject.
- Gensim Word2Vec Model in Python: Used for generating word recommendations.


