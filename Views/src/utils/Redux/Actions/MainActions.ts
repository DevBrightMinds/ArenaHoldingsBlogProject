import Article from "../../interfaces/Article"


export const setSelectedArticle = (article: Article) => {
    return {
        type: "SELECTEDARTICLE",
        payload: article
    }
}
