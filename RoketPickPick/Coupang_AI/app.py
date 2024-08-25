import sqlite3
import streamlit as st
from dotenv import load_dotenv
from openai import OpenAI
from streamlit_chat import message
import os

# OpenAI API 설정
load_dotenv()
client = OpenAI()
client.api_key = os.getenv('OPENAI_API_KEY')

# 데이터베이스 연결 함수
def get_db_connection():
    conn = sqlite3.connect('coupang_kitchen.db')
    return conn

# LLM을 통해 요리를 추천하는 함수
def generate_response(prompt, recipe_list):
    recipes_text = ", ".join(recipe_list)
    full_prompt = f"{prompt}\n무조건 다음 요리 중에서 추천해줘, 절대 새로운 요리를 생성하지마: {recipes_text}"

    response = client.chat.completions.create(
        model="gpt-3.5-turbo",
        messages=[
            {"role": "system", "content": "너는 쿠팡 키친의 요리 추천 에이전트야. 사용자가 원하는 요리 주제를 제공하면, 쿠팡 키친 데이터베이스에 있는 요리를 기반으로 적절한 요리를 추천해줘."},
            {"role": "user", "content": full_prompt}
        ],
        max_tokens=1024,
        stop=None,
        temperature=0.7,
        top_p=1,
    )
    
    recommended_recipes = response.choices[0].message.content.strip().split("\n")
    return recommended_recipes

# Streamlit 애플리케이션 UI 설정
st.header("Coupang Kitchen Agent_AI")

# 세션 스테이트 초기화
if 'generated' not in st.session_state:
    st.session_state['generated'] = []
 
if 'past' not in st.session_state:
    st.session_state['past'] = []

if 'recommendations' not in st.session_state:
    st.session_state['recommendations'] = []

if 'show_buttons' not in st.session_state:
    st.session_state['show_buttons'] = False

# 입력 폼
with st.form('form', clear_on_submit=True):
    user_input = st.text_input('어떤 상황의 요리를 추천해 드릴까요? ex) 방학맞은 아이들 간식', '', key='input')
    submitted = st.form_submit_button('→')

if submitted and user_input:
    # 여기에 디비에서 가져온 요리 리스트를 사용할 수 있음 (데모에서는 예제 리스트 사용)
    # 실제로는 DB에서 가져와야 함
    recipe_list = ["갈비찜", "딸기케이크", "피자"]  # 예제 리스트
    output = generate_response(user_input, recipe_list)
    st.session_state.past.append(user_input)
    st.session_state.generated.append("\n".join(output))  # 추천된 요리들을 화면에 표시
    st.session_state.recommendations = output  # LLM이 추천한 요리들만 저장
    st.session_state.show_buttons = True

# 대화 히스토리 표시
if st.session_state['generated']:
    for i in range(len(st.session_state['generated'])-1, -1, -1):
        message(st.session_state['past'][i], is_user=True, key=str(i) + '_user')
        message(st.session_state["generated"][i], key=str(i))

# LLM이 추천한 요리들로 쇼핑할지 묻기
if st.session_state.show_buttons:
    st.write("추천된 요리들로 쇼핑을 할까요?")
    col1, col2 = st.columns(2)
    with col1:
        if st.button('예'):
            st.write("아래에서 원하는 요리를 선택하세요:")
            for recipe in st.session_state.recommendations:
                if st.button(recipe):
                    st.write(f"{recipe}를 선택하셨습니다. 해당 요리의 재료를 장바구니에 추가합니다.")
                    # 여기서 장바구니로 넘어가는 로직을 추가할 수 있습니다.

    with col2:
        if st.button('아니요'):
            st.session_state.generated = []
            st.session_state.past = []
            st.session_state.recommendations = []
            st.session_state.show_buttons = False
            st.experimental_rerun()  # 애플리케이션을 다시 실행하여 처음부터 시작
