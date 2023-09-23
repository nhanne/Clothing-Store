import React from 'react'
import { useContext } from 'react'
import { FilterContext } from '../storeContext.js'

export default function Pagination() {
    const context = useContext(FilterContext)

    return (
        <div id="pagination" className="MenuTrang pagination-container">
            <ul className="pagination">
                {context.totalPages.current > 1 ? (
                    <>
                        {Array.from({ length: context.totalPages.current }, (_, i) => (
                            <li className={`page-item`} key={i}>
                                <a
                                    onClick={() => context.setPage(i + 1)}
                                    className={`page-link ${i + 1 === context.page ? 'active' : ''}`}
                                >
                                    {i + 1}
                                </a>
                            </li>
                        ))}
                    </>
                ) : (
                    ''
                )}
            </ul>
        </div>
    )
}
