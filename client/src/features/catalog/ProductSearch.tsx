import { debounce, TextField } from "@mui/material";
import { useState } from "react";
import { useAppSelector, useAppDispatch } from "../../app/store/configureStore";
import { setProductParams } from "./catalogSlice";

export default function Search() {
    const { productParams } = useAppSelector(state => state.catalog);
    const [keyword, setKeyword] = useState(productParams.keyword);
    const dispatch = useAppDispatch();

    const debouncedSearch = debounce((event: any) => {
        dispatch(setProductParams({ keyword: event.target.value }))
    }, 1000)

    return (
        <TextField
            label='Search products'
            variant='outlined'
            fullWidth
            value={keyword || ''}
            onChange={(event: any) => {
                setKeyword(event.target.value);
                debouncedSearch(event);
            }}
        />
    )
}