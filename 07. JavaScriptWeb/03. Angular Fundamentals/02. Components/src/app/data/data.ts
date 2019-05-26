import { Article } from "../models/article.model";
import { data } from "./seed";

export class ArticleData {
    getData() : Article[] {
        let articles : Article[] = [];
        console.log(data);
        for(let i = 0; i < data.length; i++) {
            var article = data[i];

            articles[i] = new Article(article.title, article.description,
                                      article.author, article.imageUrl);
        }

        return articles;
    }
}