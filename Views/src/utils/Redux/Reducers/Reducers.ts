export const SelectedArticle = (state = {}, action: any) => {
    switch (action.type) {
        case "SELECTEDARTICLE":
            return action.payload;
        default:
            return state;
    }
}