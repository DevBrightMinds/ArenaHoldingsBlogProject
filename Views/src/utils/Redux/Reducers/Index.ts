import { combineReducers } from "redux";

import {
    SelectedArticle,
} from "./Reducers";

const allReducers = combineReducers({
    SelectedArticle
});

export default allReducers;